using Android.Content;
using Android.Views;
using System;

/*
 * Copyright (C) 2015 Zhang Rui <bbcallen@gmail.com>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace IjkplayerXamarin.Droid
{


    public sealed class MeasureHelper
    {
        private WeakReference<View> mWeakView;

        private int mVideoWidth;
        private int mVideoHeight;
        private int mVideoSarNum;
        private int mVideoSarDen;

        private int mVideoRotationDegree;

        private int mMeasuredWidth;
        private int mMeasuredHeight;

        private int mCurrentAspectRatio = IRenderView_Fields.AR_ASPECT_FIT_PARENT;

        public MeasureHelper(View view)
        {
            mWeakView = new WeakReference<View>(view);
        }

        public View View
        {
            get
            {
                if (mWeakView == null)
                {
                    return null;
                }
                View view = null;
                mWeakView.TryGetTarget(out view);
                return view;
            }
        }

        public void setVideoSize(int videoWidth, int videoHeight)
        {
            mVideoWidth = videoWidth;
            mVideoHeight = videoHeight;
        }

        public void setVideoSampleAspectRatio(int videoSarNum, int videoSarDen)
        {
            mVideoSarNum = videoSarNum;
            mVideoSarDen = videoSarDen;
        }

        public int VideoRotation
        {
            set
            {
                mVideoRotationDegree = value;
            }
        }

        /// <summary>
        /// Must be called by View.onMeasure(int, int)
        /// </summary>
        /// <param name="widthMeasureSpec"> </param>
        /// <param name="heightMeasureSpec"> </param>
        public void doMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            //Log.i("@@@@", "onMeasure(" + MeasureSpec.toString(widthMeasureSpec) + ", "
            //        + MeasureSpec.toString(heightMeasureSpec) + ")");
            if (mVideoRotationDegree == 90 || mVideoRotationDegree == 270)
            {
                int tempSpec = widthMeasureSpec;
                widthMeasureSpec = heightMeasureSpec;
                heightMeasureSpec = tempSpec;
            }

            int width = View.GetDefaultSize(mVideoWidth, widthMeasureSpec);
            int height = View.GetDefaultSize(mVideoHeight, heightMeasureSpec);
            if (mCurrentAspectRatio == IRenderView_Fields.AR_MATCH_PARENT)
            {
                width = widthMeasureSpec;
                height = heightMeasureSpec;
            }
            else if (mVideoWidth > 0 && mVideoHeight > 0)
            {
                var widthSpecMode = View.MeasureSpec.GetMode(widthMeasureSpec);
                int widthSpecSize = View.MeasureSpec.GetSize(widthMeasureSpec);
                var heightSpecMode = View.MeasureSpec.GetMode(heightMeasureSpec);
                int heightSpecSize = View.MeasureSpec.GetSize(heightMeasureSpec);

                if (widthSpecMode == MeasureSpecMode.AtMost && heightSpecMode == MeasureSpecMode.AtMost)
                {
                    float specAspectRatio = (float)widthSpecSize / (float)heightSpecSize;
                    float displayAspectRatio;
                    switch (mCurrentAspectRatio)
                    {
                        case IRenderView_Fields.AR_16_9_FIT_PARENT:
                            displayAspectRatio = 16.0f / 9.0f;
                            if (mVideoRotationDegree == 90 || mVideoRotationDegree == 270)
                            {
                                displayAspectRatio = 1.0f / displayAspectRatio;
                            }
                            break;
                        case IRenderView_Fields.AR_4_3_FIT_PARENT:
                            displayAspectRatio = 4.0f / 3.0f;
                            if (mVideoRotationDegree == 90 || mVideoRotationDegree == 270)
                            {
                                displayAspectRatio = 1.0f / displayAspectRatio;
                            }
                            break;
                        case IRenderView_Fields.AR_ASPECT_FIT_PARENT:
                        case IRenderView_Fields.AR_ASPECT_FILL_PARENT:
                        case IRenderView_Fields.AR_ASPECT_WRAP_CONTENT:
                        default:
                            displayAspectRatio = (float)mVideoWidth / (float)mVideoHeight;
                            if (mVideoSarNum > 0 && mVideoSarDen > 0)
                            {
                                displayAspectRatio = displayAspectRatio * mVideoSarNum / mVideoSarDen;
                            }
                            break;
                    }
                    bool shouldBeWider = displayAspectRatio > specAspectRatio;

                    switch (mCurrentAspectRatio)
                    {
                        case IRenderView_Fields.AR_ASPECT_FIT_PARENT:
                        case IRenderView_Fields.AR_16_9_FIT_PARENT:
                        case IRenderView_Fields.AR_4_3_FIT_PARENT:
                            if (shouldBeWider)
                            {
                                // too wide, fix width
                                width = widthSpecSize;
                                height = (int)(width / displayAspectRatio);
                            }
                            else
                            {
                                // too high, fix height
                                height = heightSpecSize;
                                width = (int)(height * displayAspectRatio);
                            }
                            break;
                        case IRenderView_Fields.AR_ASPECT_FILL_PARENT:
                            if (shouldBeWider)
                            {
                                // not high enough, fix height
                                height = heightSpecSize;
                                width = (int)(height * displayAspectRatio);
                            }
                            else
                            {
                                // not wide enough, fix width
                                width = widthSpecSize;
                                height = (int)(width / displayAspectRatio);
                            }
                            break;
                        case IRenderView_Fields.AR_ASPECT_WRAP_CONTENT:
                        default:
                            if (shouldBeWider)
                            {
                                // too wide, fix width
                                width = Math.Min(mVideoWidth, widthSpecSize);
                                height = (int)(width / displayAspectRatio);
                            }
                            else
                            {
                                // too high, fix height
                                height = Math.Min(mVideoHeight, heightSpecSize);
                                width = (int)(height * displayAspectRatio);
                            }
                            break;
                    }
                }
                else if (widthSpecMode == MeasureSpecMode.Exactly && heightSpecMode == MeasureSpecMode.Exactly)
                {
                    // the size is fixed
                    width = widthSpecSize;
                    height = heightSpecSize;

                    // for compatibility, we adjust size based on aspect ratio
                    if (mVideoWidth * height < width * mVideoHeight)
                    {
                        //Log.i("@@@", "image too wide, correcting");
                        width = height * mVideoWidth / mVideoHeight;
                    }
                    else if (mVideoWidth * height > width * mVideoHeight)
                    {
                        //Log.i("@@@", "image too tall, correcting");
                        height = width * mVideoHeight / mVideoWidth;
                    }
                }
                else if (widthSpecMode == MeasureSpecMode.Exactly)
                {
                    // only the width is fixed, adjust the height to match aspect ratio if possible
                    width = widthSpecSize;
                    height = width * mVideoHeight / mVideoWidth;
                    if (heightSpecMode == MeasureSpecMode.AtMost && height > heightSpecSize)
                    {
                        // couldn't match aspect ratio within the constraints
                        height = heightSpecSize;
                    }
                }
                else if (heightSpecMode == MeasureSpecMode.Exactly)
                {
                    // only the height is fixed, adjust the width to match aspect ratio if possible
                    height = heightSpecSize;
                    width = height * mVideoWidth / mVideoHeight;
                    if (widthSpecMode == MeasureSpecMode.AtMost && width > widthSpecSize)
                    {
                        // couldn't match aspect ratio within the constraints
                        width = widthSpecSize;
                    }
                }
                else
                {
                    // neither the width nor the height are fixed, try to use actual video size
                    width = mVideoWidth;
                    height = mVideoHeight;
                    if (heightSpecMode == MeasureSpecMode.AtMost && height > heightSpecSize)
                    {
                        // too tall, decrease both width and height
                        height = heightSpecSize;
                        width = height * mVideoWidth / mVideoHeight;
                    }
                    if (widthSpecMode == MeasureSpecMode.AtMost && width > widthSpecSize)
                    {
                        // too wide, decrease both width and height
                        width = widthSpecSize;
                        height = width * mVideoHeight / mVideoWidth;
                    }
                }
            }
            else
            {
                // no size yet, just adopt the given spec sizes
            }

            mMeasuredWidth = width;
            mMeasuredHeight = height;
        }

        public int MeasuredWidth
        {
            get
            {
                return mMeasuredWidth;
            }
        }

        public int MeasuredHeight
        {
            get
            {
                return mMeasuredHeight;
            }
        }

        public int AspectRatio
        {
            set
            {
                mCurrentAspectRatio = value;
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @NonNull public static String getAspectRatioText(android.content.Context context, int aspectRatio)
        public static string getAspectRatioText(Context context, int aspectRatio)
        {
            string text;
            switch (aspectRatio)
            {
                case IRenderView_Fields.AR_ASPECT_FIT_PARENT:
                    text = "Aspect / Fit parent";
                    break;
                case IRenderView_Fields.AR_ASPECT_FILL_PARENT:
                    text = "Aspect / Fill parent";
                    break;
                case IRenderView_Fields.AR_ASPECT_WRAP_CONTENT:
                    text = "Aspect / Wrap conten";
                    break;
                case IRenderView_Fields.AR_MATCH_PARENT:
                    text = "Free / Fill parent";
                    break;
                case IRenderView_Fields.AR_16_9_FIT_PARENT:
                    text = "16:9 / Fit parent";
                    break;
                case IRenderView_Fields.AR_4_3_FIT_PARENT:
                    text = "4:3 / Fit parent";
                    break;
                default:
                    text = "NA";
                    break;
            }
            return text;
        }
    }

}