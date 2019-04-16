using System.Collections.Generic;
using System.Collections.Concurrent;
using Android.Util;
using Android.Content;
using Android.Views;
using Android.Graphics;
using TV.Danmaku.Ijk.Media.Player;
using Android.OS;
using System;
using Android.Views.Accessibility;

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


    //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
    //ORIGINAL LINE: @TargetApi(Build.VERSION_CODES.ICE_CREAM_SANDWICH) public class TextureRenderView extends android.view.TextureView implements IRenderView
    public class TextureRenderView : TextureView, IRenderView
    {
        private const string TAG = "TextureRenderView";
        private MeasureHelper mMeasureHelper;

        public TextureRenderView(Context context) : base(context)
        {
            initView(context);
        }

        public TextureRenderView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            initView(context);
        }

        public TextureRenderView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            initView(context);
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @TargetApi(android.os.Build.VERSION_CODES.LOLLIPOP) public TextureRenderView(android.content.Context context, android.util.AttributeSet attrs, int defStyleAttr, int defStyleRes)
        public TextureRenderView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            initView(context);
        }

        private void initView(Context context)
        {
            mMeasureHelper = new MeasureHelper(this);
            mSurfaceCallback = new SurfaceCallback(this);
            SurfaceTextureListener = mSurfaceCallback;
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
            return false;
        }

        protected override void OnDetachedFromWindow()
        {
            mSurfaceCallback.willDetachFromWindow();
            base.OnDetachedFromWindow();
            mSurfaceCallback.didDetachFromWindow();
        }

        //--------------------
        // Layout & Measure
        //--------------------
        public virtual void setVideoSize(int videoWidth, int videoHeight)
        {
            if (videoWidth > 0 && videoHeight > 0)
            {
                mMeasureHelper.setVideoSize(videoWidth, videoHeight);
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
                mMeasureHelper.VideoRotation = value;
                Rotation = value;
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
        // TextureViewHolder
        //--------------------

        public virtual IRenderView_ISurfaceHolder SurfaceHolder
        {
            get
            {
                return new InternalSurfaceHolder(this, mSurfaceCallback.mSurfaceTexture, mSurfaceCallback);
            }
        }

        private sealed class InternalSurfaceHolder : IRenderView_ISurfaceHolder
        {
            internal TextureRenderView mTextureView;
            internal SurfaceTexture mSurfaceTexture;
            internal ISurfaceTextureHost mSurfaceTextureHost;

            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: public InternalSurfaceHolder(@NonNull TextureRenderView textureView, @Nullable android.graphics.SurfaceTexture surfaceTexture, @NonNull tv.danmaku.ijk.media.player.ISurfaceTextureHost surfaceTextureHost)
            public InternalSurfaceHolder(TextureRenderView textureView, SurfaceTexture surfaceTexture, ISurfaceTextureHost surfaceTextureHost)
            {
                mTextureView = textureView;
                mSurfaceTexture = surfaceTexture;
                mSurfaceTextureHost = surfaceTextureHost;
            }

            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: @TargetApi(android.os.Build.VERSION_CODES.JELLY_BEAN) public void bindToMediaPlayer(tv.danmaku.ijk.media.player.IMediaPlayer mp)
            public void bindToMediaPlayer(IMediaPlayer mp)
            {
                if (mp == null)
                {
                    return;
                }

                if ((Build.VERSION.SdkInt >= Build.VERSION_CODES.JellyBean) && (mp is ISurfaceTextureHolder))
                {
                    ISurfaceTextureHolder textureHolder = (ISurfaceTextureHolder)mp;
                    mTextureView.mSurfaceCallback.OwnSurfaceTexture = false;

                    SurfaceTexture surfaceTexture = textureHolder.SurfaceTexture;
                    if (surfaceTexture != null)
                    {
                        mTextureView.SurfaceTexture = surfaceTexture;
                    }
                    else
                    {
                        textureHolder.SurfaceTexture = mSurfaceTexture;
                        textureHolder.SetSurfaceTextureHost(mTextureView.mSurfaceCallback);
                    }
                }
                else
                {
                    mp.SetSurface(openSurface());
                }
            }

            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: @NonNull @Override public IRenderView getRenderView()
            public IRenderView RenderView
            {
                get
                {
                    return mTextureView;
                }
            }

            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: @Nullable @Override public android.view.SurfaceHolder getSurfaceHolder()
            public ISurfaceHolder SurfaceHolder
            {
                get
                {
                    return null;
                }
            }

            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: @Nullable @Override public android.graphics.SurfaceTexture getSurfaceTexture()
            public SurfaceTexture SurfaceTexture
            {
                get
                {
                    return mSurfaceTexture;
                }
            }

            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: @Nullable @Override public android.view.Surface openSurface()
            public Surface openSurface()
            {
                if (mSurfaceTexture == null)
                {
                    return null;
                }
                return new Surface(mSurfaceTexture);
            }
        }

        //-------------------------
        // SurfaceHolder.Callback
        //-------------------------

        public virtual void addRenderCallback(IRenderView_IRenderCallback callback)
        {
            mSurfaceCallback.addRenderCallback(callback);
        }

        public virtual void removeRenderCallback(IRenderView_IRenderCallback callback)
        {
            mSurfaceCallback.removeRenderCallback(callback);
        }

        private SurfaceCallback mSurfaceCallback;

        private sealed class SurfaceCallback : Java.Lang.Object, TextureView.ISurfaceTextureListener, ISurfaceTextureHost
        {
            internal SurfaceTexture mSurfaceTexture;
            internal bool mIsFormatChanged;
            internal int mWidth;
            internal int mHeight;

            internal bool mOwnSurfaceTexture = true;
            internal bool mWillDetachFromWindow = false;
            internal bool mDidDetachFromWindow = false;

            internal WeakReference<TextureRenderView> mWeakRenderView;
            internal IDictionary<IRenderView_IRenderCallback, object> mRenderCallbackMap = new ConcurrentDictionary<IRenderView_IRenderCallback, object>();

            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: public SurfaceCallback(@NonNull TextureRenderView renderView)
            public SurfaceCallback(TextureRenderView renderView)
            {
                mWeakRenderView = new WeakReference<TextureRenderView>(renderView);
            }

            public bool OwnSurfaceTexture
            {
                set
                {
                    mOwnSurfaceTexture = value;
                }
            }

            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: public void addRenderCallback(@NonNull IRenderCallback callback)
            public void addRenderCallback(IRenderView_IRenderCallback callback)
            {
                mRenderCallbackMap[callback] = callback;

                IRenderView_ISurfaceHolder surfaceHolder = null;
                if (mSurfaceTexture != null)
                {
                    if (surfaceHolder == null)
                    {
                        TextureRenderView texture = null;
                        mWeakRenderView.TryGetTarget(out texture);
                        surfaceHolder = new InternalSurfaceHolder(texture, mSurfaceTexture, this);
                    }
                    callback.onSurfaceCreated(surfaceHolder, mWidth, mHeight);
                }

                if (mIsFormatChanged)
                {
                    if (surfaceHolder == null)
                    {
                        TextureRenderView texture = null;
                        mWeakRenderView.TryGetTarget(out texture);
                        surfaceHolder = new InternalSurfaceHolder(texture, mSurfaceTexture, this);
                    }
                    callback.onSurfaceChanged(surfaceHolder, 0, mWidth, mHeight);
                }
            }

            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: public void removeRenderCallback(@NonNull IRenderCallback callback)
            public void removeRenderCallback(IRenderView_IRenderCallback callback)
            {
                mRenderCallbackMap.Remove(callback);
            }

            public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
            {
                mSurfaceTexture = surface;
                mIsFormatChanged = false;
                mWidth = 0;
                mHeight = 0;
                TextureRenderView texture = null;
                mWeakRenderView.TryGetTarget(out texture);
                IRenderView_ISurfaceHolder surfaceHolder = new InternalSurfaceHolder(texture, surface, this);
                foreach (IRenderView_IRenderCallback renderCallback in mRenderCallbackMap.Keys)
                {
                    renderCallback.onSurfaceCreated(surfaceHolder, 0, 0);
                }
            }

            public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
            {
                mSurfaceTexture = surface;
                mIsFormatChanged = true;
                mWidth = width;
                mHeight = height;
                TextureRenderView texture = null;
                mWeakRenderView.TryGetTarget(out texture);
                IRenderView_ISurfaceHolder surfaceHolder = new InternalSurfaceHolder(texture, surface, this);
                foreach (IRenderView_IRenderCallback renderCallback in mRenderCallbackMap.Keys)
                {
                    renderCallback.onSurfaceChanged(surfaceHolder, 0, width, height);
                }
            }

            public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
            {
                mSurfaceTexture = surface;
                mIsFormatChanged = false;
                mWidth = 0;
                mHeight = 0;
                TextureRenderView texture = null;
                mWeakRenderView.TryGetTarget(out texture);
                IRenderView_ISurfaceHolder surfaceHolder = new InternalSurfaceHolder(texture, surface, this);
                foreach (IRenderView_IRenderCallback renderCallback in mRenderCallbackMap.Keys)
                {
                    renderCallback.onSurfaceDestroyed(surfaceHolder);
                }

                Log.Debug(TAG, "onSurfaceTextureDestroyed: destroy: " + mOwnSurfaceTexture);
                return mOwnSurfaceTexture;
            }

            public void OnSurfaceTextureUpdated(SurfaceTexture surface)
            {
            }

            //-------------------------
            // ISurfaceTextureHost
            //-------------------------

            public void ReleaseSurfaceTexture(SurfaceTexture surfaceTexture)
            {
                if (surfaceTexture == null)
                {
                    Log.Debug(TAG, "releaseSurfaceTexture: null");
                }
                else if (mDidDetachFromWindow)
                {
                    if (surfaceTexture != mSurfaceTexture)
                    {
                        Log.Debug(TAG, "releaseSurfaceTexture: didDetachFromWindow(): release different SurfaceTexture");
                        surfaceTexture.Release();
                    }
                    else if (!mOwnSurfaceTexture)
                    {
                        Log.Debug(TAG, "releaseSurfaceTexture: didDetachFromWindow(): release detached SurfaceTexture");
                        surfaceTexture.Release();
                    }
                    else
                    {
                        Log.Debug(TAG, "releaseSurfaceTexture: didDetachFromWindow(): already released by TextureView");
                    }
                }
                else if (mWillDetachFromWindow)
                {
                    if (surfaceTexture != mSurfaceTexture)
                    {
                        Log.Debug(TAG, "releaseSurfaceTexture: willDetachFromWindow(): release different SurfaceTexture");
                        surfaceTexture.Release();
                    }
                    else if (!mOwnSurfaceTexture)
                    {
                        Log.Debug(TAG, "releaseSurfaceTexture: willDetachFromWindow(): re-attach SurfaceTexture to TextureView");
                        OwnSurfaceTexture = true;
                    }
                    else
                    {
                        Log.Debug(TAG, "releaseSurfaceTexture: willDetachFromWindow(): will released by TextureView");
                    }
                }
                else
                {
                    if (surfaceTexture != mSurfaceTexture)
                    {
                        Log.Debug(TAG, "releaseSurfaceTexture: alive: release different SurfaceTexture");
                        surfaceTexture.Release();
                    }
                    else if (!mOwnSurfaceTexture)
                    {
                        Log.Debug(TAG, "releaseSurfaceTexture: alive: re-attach SurfaceTexture to TextureView");
                        OwnSurfaceTexture = true;
                    }
                    else
                    {
                        Log.Debug(TAG, "releaseSurfaceTexture: alive: will released by TextureView");
                    }
                }
            }

            public void willDetachFromWindow()
            {
                Log.Debug(TAG, "willDetachFromWindow()");
                mWillDetachFromWindow = true;
            }

            public void didDetachFromWindow()
            {
                Log.Debug(TAG, "didDetachFromWindow()");
                mDidDetachFromWindow = true;
            }
        }

        //--------------------
        // Accessibility
        //--------------------

        public override void OnInitializeAccessibilityEvent(AccessibilityEvent @event)
        {
            base.OnInitializeAccessibilityEvent(@event);
            //JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
            @event.ClassName = typeof(TextureRenderView).FullName;
        }

        public override void OnInitializeAccessibilityNodeInfo(AccessibilityNodeInfo info)
        {
            base.OnInitializeAccessibilityNodeInfo(info);
            //JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
            info.ClassName = typeof(TextureRenderView).FullName;
        }
    }

}