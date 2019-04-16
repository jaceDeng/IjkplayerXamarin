using System.Collections.Generic;
using System.Collections.Concurrent;
using Android.Views;
using Android.Content;
using Android.Util;
using System;
using Android.Views.Accessibility;
using Android.OS;
using Android.Graphics;
using Android.Runtime;
using TV.Danmaku.Ijk.Media.Player;

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


    public class SurfaceRenderView : SurfaceView, IRenderView
    {
        private MeasureHelper mMeasureHelper;

        public SurfaceRenderView(Context context) : base(context)
        {
            initView(context);
        }

        public SurfaceRenderView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            initView(context);
        }

        public SurfaceRenderView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            initView(context);
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @TargetApi(android.os.Build.VERSION_CODES.LOLLIPOP) public SurfaceRenderView(android.content.Context context, android.util.AttributeSet attrs, int defStyleAttr, int defStyleRes)
        public SurfaceRenderView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            initView(context);
        }

        private void initView(Context context)
        {
            mMeasureHelper = new MeasureHelper(this);
            mSurfaceCallback = new SurfaceCallback(this);
            Holder.AddCallback(mSurfaceCallback);
            //noinspection deprecation
            Holder.SetType(SurfaceType.Normal);
        }

        public virtual View View
        {
            get
            {
                return this;
            }
        }

        public virtual bool shouldWaitForResize()
        {
            return true;
        }

        //--------------------
        // Layout & Measure
        //--------------------
        public virtual void setVideoSize(int videoWidth, int videoHeight)
        {
            if (videoWidth > 0 && videoHeight > 0)
            {
                mMeasureHelper.setVideoSize(videoWidth, videoHeight);
                Holder.SetFixedSize(videoWidth, videoHeight);
                RequestLayout();
            }
        }

        public virtual void setVideoSampleAspectRatio(int videoSarNum, int videoSarDen)
        {
            if (videoSarNum > 0 && videoSarDen > 0)
            {
                mMeasureHelper.setVideoSampleAspectRatio(videoSarNum, videoSarDen);
                RequestLayout();
            }
        }

        public virtual int VideoRotation
        {
            set
            {
                Log.Error("", "SurfaceView doesn't support rotation (" + value + ")!\n");
            }
        }

        public virtual int AspectRatio
        {
            set
            {
                mMeasureHelper.AspectRatio = value;
                RequestLayout();
            }
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            mMeasureHelper.doMeasure(widthMeasureSpec, heightMeasureSpec);
            SetMeasuredDimension(mMeasureHelper.MeasuredWidth, mMeasureHelper.MeasuredHeight);
        }

        //--------------------
        // SurfaceViewHolder
        //--------------------

        private sealed class InternalSurfaceHolder : IRenderView_ISurfaceHolder
        {
            internal SurfaceRenderView mSurfaceView;
            internal ISurfaceHolder mSurfaceHolder;

            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: public InternalSurfaceHolder(@NonNull SurfaceRenderView surfaceView, @Nullable android.view.SurfaceHolder surfaceHolder)
            public InternalSurfaceHolder(SurfaceRenderView surfaceView, ISurfaceHolder surfaceHolder)
            {
                mSurfaceView = surfaceView;
                mSurfaceHolder = surfaceHolder;
            }

            public void bindToMediaPlayer(IMediaPlayer mp)
            {
                if (mp != null)
                {
                    if ((Build.VERSION.SdkInt >= Build.VERSION_CODES.JellyBean) && (mp is ISurfaceTextureHolder))
                    {
                        ISurfaceTextureHolder textureHolder = (ISurfaceTextureHolder)mp;
                        textureHolder.SurfaceTexture = null;
                    }
                    mp.SetDisplay(mSurfaceHolder);
                }
            }

            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: @NonNull @Override public IRenderView getRenderView()
            public IRenderView RenderView
            {
                get
                {
                    return mSurfaceView;
                }
            }

            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: @Nullable @Override public android.view.SurfaceHolder getSurfaceHolder()
            public ISurfaceHolder SurfaceHolder
            {
                get
                {
                    return mSurfaceHolder;
                }
            }

            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: @Nullable @Override public android.graphics.SurfaceTexture getSurfaceTexture()
            public SurfaceTexture SurfaceTexture
            {
                get
                {
                    return null;
                }
            }



            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: @Nullable @Override public android.view.Surface openSurface()
            public Surface openSurface()
            {
                if (mSurfaceHolder == null)
                {
                    return null;
                }
                return mSurfaceHolder.Surface;
            }
        }

        //-------------------------
        // SurfaceHolder.Callback
        //-------------------------

        public virtual void addRenderCallback(IRenderView_IRenderCallback callback)
        {
            mSurfaceCallback.AddRenderCallback(callback);
        }

        public virtual void removeRenderCallback(IRenderView_IRenderCallback callback)
        {
            mSurfaceCallback.removeRenderCallback(callback);
        }

        private SurfaceCallback mSurfaceCallback;

        private sealed class SurfaceCallback : Java.Lang.Object, ISurfaceHolderCallback
        {
            internal ISurfaceHolder mSurfaceHolder;
            internal bool mIsFormatChanged;
            internal int mFormat;
            internal int mWidth;
            internal int mHeight;

            internal WeakReference<SurfaceRenderView> mWeakSurfaceView;
            internal IDictionary<IRenderView_IRenderCallback, object> mRenderCallbackMap = new ConcurrentDictionary<IRenderView_IRenderCallback, object>();



            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: public SurfaceCallback(@NonNull SurfaceRenderView surfaceView)
            public SurfaceCallback(SurfaceRenderView surfaceView)
            {
                mWeakSurfaceView = new WeakReference<SurfaceRenderView>(surfaceView);
            }

            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: public void addRenderCallback(@NonNull IRenderCallback callback)
            public void AddRenderCallback(IRenderView_IRenderCallback callback)
            {
                mRenderCallbackMap[callback] = callback;

                IRenderView_ISurfaceHolder surfaceHolder = null;
                if (mSurfaceHolder != null)
                {
                    if (surfaceHolder == null)
                    {
                        SurfaceRenderView t = null;
                        mWeakSurfaceView.TryGetTarget(out t);
                        surfaceHolder = new InternalSurfaceHolder(t, mSurfaceHolder);
                    }
                    callback.onSurfaceCreated(surfaceHolder, mWidth, mHeight);
                }

                if (mIsFormatChanged)
                {
                    if (surfaceHolder == null)
                    {
                        SurfaceRenderView t = null;
                        mWeakSurfaceView.TryGetTarget(out t);
                        surfaceHolder = new InternalSurfaceHolder(t, mSurfaceHolder);
                    }
                    callback.onSurfaceChanged(surfaceHolder, mFormat, mWidth, mHeight);
                }
            }

            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: public void removeRenderCallback(@NonNull IRenderCallback callback)
            public void removeRenderCallback(IRenderView_IRenderCallback callback)
            {
                mRenderCallbackMap.Remove(callback);
            }

            public void SurfaceCreated(ISurfaceHolder holder)
            {
                mSurfaceHolder = holder;
                mIsFormatChanged = false;
                mFormat = 0;
                mWidth = 0;
                mHeight = 0;
                SurfaceRenderView t = null;
                mWeakSurfaceView.TryGetTarget(out t);
                IRenderView_ISurfaceHolder surfaceHolder = new InternalSurfaceHolder(t, mSurfaceHolder);
                foreach (IRenderView_IRenderCallback renderCallback in mRenderCallbackMap.Keys)
                {
                    renderCallback.onSurfaceCreated(surfaceHolder, 0, 0);
                }
            }

            public void SurfaceDestroyed(ISurfaceHolder holder)
            {
                mSurfaceHolder = null;
                mIsFormatChanged = false;
                mFormat = 0;
                mWidth = 0;
                mHeight = 0;
                SurfaceRenderView t = null;

                mWeakSurfaceView.TryGetTarget(out t);
                IRenderView_ISurfaceHolder surfaceHolder = new InternalSurfaceHolder(t, mSurfaceHolder);
                foreach (IRenderView_IRenderCallback renderCallback in mRenderCallbackMap.Keys)
                {
                    renderCallback.onSurfaceDestroyed(surfaceHolder);
                }
            }

            public void SurfaceChanged(ISurfaceHolder holder, [GeneratedEnum] Format format, int width, int height)
            {
                mSurfaceHolder = holder;
                mIsFormatChanged = true;
                mFormat = (int)format;
                mWidth = width;
                mHeight = height;

                // mMeasureHelper.setVideoSize(width, height);
                SurfaceRenderView t = null;

                mWeakSurfaceView.TryGetTarget(out t);
                IRenderView_ISurfaceHolder surfaceHolder = new InternalSurfaceHolder(t, mSurfaceHolder);
                foreach (IRenderView_IRenderCallback renderCallback in mRenderCallbackMap.Keys)
                {
                    renderCallback.onSurfaceChanged(surfaceHolder, (int)format, width, height);
                }
            }




        }

        //--------------------
        // Accessibility
        //--------------------

        public void OnInitializeAccessibilityEvent(AccessibilityEvent @event)
        {
            base.OnInitializeAccessibilityEvent(@event);
            //JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
            @event.ClassName = typeof(SurfaceRenderView).FullName;
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @TargetApi(android.os.Build.VERSION_CODES.ICE_CREAM_SANDWICH) @Override public void onInitializeAccessibilityNodeInfo(android.view.accessibility.AccessibilityNodeInfo info)
        public void OnInitializeAccessibilityNodeInfo(AccessibilityNodeInfo info)
        {
            base.OnInitializeAccessibilityNodeInfo(info);
            if (Build.VERSION.SdkInt >= Build.VERSION_CODES.IceCreamSandwich)
            {
                //JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
                info.ClassName = typeof(SurfaceRenderView).FullName;
            }
        }
    }

}