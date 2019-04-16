using Android.Content;
using Android.Content.Res;
using Android.Media;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
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


    public class IjkVideoView : FrameLayout, MediaController.IMediaPlayerControl
    {
        private bool InstanceFieldsInitialized = false;

        private void InitializeInstanceFields()
        {
            mCurrentAspectRatio = s_allAspectRatio[mCurrentAspectRatioIndex];
            mSHCallback = new IRenderView_IRenderCallbackAnonymousInnerClass(this);
            mErrorListener = new OnErrorListenerAnonymousInnerClass(this);
            mSizeChangedListener = new OnVideoSizeChangedListenerAnonymousInnerClass(this);
            mBufferingUpdateListener = new OnBufferingUpdateListenerAnonymousInnerClass(this);
            mCompletionListener = new OnCompletionListenerAnonymousInnerClass(this);
            mPreparedListener = new OnPreparedListenerAnonymousInnerClass(this);
            mInfoListener = new OnInfoListenerAnonymousInnerClass(this);
        }

        private string TAG = "IjkVideoView";
        // settable by the client
        private Uri mUri;
        private IDictionary<string, string> mHeaders;

        // all possible internal states
        public const int STATE_ERROR = -1;
        public const int STATE_IDLE = 0;
        public const int STATE_PREPARING = 1;
        public const int STATE_PREPARED = 2;
        public const int STATE_PLAYING = 3;
        public const int STATE_PAUSED = 4;
        public const int STATE_PLAYBACK_COMPLETED = 5;

        public virtual int CurrentState
        {
            get
            {
                return mCurrentState;
            }
        }

        // mCurrentState is a VideoView object's current state.
        // mTargetState is the state that a method caller intends to reach.
        // For instance, regardless the VideoView object's current state,
        // calling pause() intends to bring the object to a target state
        // of STATE_PAUSED.
        private int mCurrentState = STATE_IDLE;
        private int mTargetState = STATE_IDLE;

        // All the stuff we need for playing and showing a video
        private IRenderView_ISurfaceHolder mSurfaceHolder = null;
        private IMediaPlayer mMediaPlayer = null;
        // private int         mAudioSession;
        private int mVideoWidth;
        private int mVideoHeight;
        private int mSurfaceWidth;
        private int mSurfaceHeight;
        private int mVideoRotationDegree;
        private IMediaController mMediaController;
        private IMediaPlayerOnCompletionListener mOnCompletionListener;
        private IMediaPlayerOnPreparedListener mOnPreparedListener;
        private int mCurrentBufferPercentage;
        private IMediaPlayerOnErrorListener mOnErrorListener;
        private IMediaPlayerOnInfoListener mOnInfoListener;
        private long mSeekWhenPrepared; // recording the seek position while preparing
        private bool mCanPause = true;
        private bool mCanSeekBack;
        private bool mCanSeekForward;

        /// <summary>
        /// Subtitle rendering widget overlaid on top of the video. </summary>
        // private RenderingWidget mSubtitleWidget;

        /// <summary>
        /// Listener for changes to subtitle data, used to redraw when needed.
        /// </summary>
        // private RenderingWidget.OnChangedListener mSubtitlesChangedListener;

        private Context mAppContext;
        private IRenderView mRenderView;
        private int mVideoSarNum;
        private int mVideoSarDen;
        private bool usingAndroidPlayer = false;
        private bool usingMediaCodec = false;
        private bool usingMediaCodecAutoRotate = false;
        private bool usingOpenSLES = false;
        private string pixelFormat = ""; //Auto Select=,RGB 565=fcc-rv16,RGB 888X=fcc-rv32,YV12=fcc-yv12,默认为RGB 888X
        private bool enableBackgroundPlay = false;
        private bool enableSurfaceView = true;
        private bool enableTextureView = false;
        private bool enableNoView = false;

        public IjkVideoView(Context context) : base(context)
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
            initVideoView(context);
        }

        public IjkVideoView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
            initVideoView(context);
        }

        public IjkVideoView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
            initVideoView(context);
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @TargetApi(android.os.Build.VERSION_CODES.LOLLIPOP) public IjkVideoView(android.content.Context context, android.util.AttributeSet attrs, int defStyleAttr, int defStyleRes)
        public IjkVideoView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
            initVideoView(context);
        }

        // REMOVED: onMeasure
        // REMOVED: onInitializeAccessibilityEvent
        // REMOVED: onInitializeAccessibilityNodeInfo
        // REMOVED: resolveAdjustedSize

        private void initVideoView(Context context)
        {
            mAppContext = context.ApplicationContext;

            initBackground();
            initRenders();

            mVideoWidth = 0;
            mVideoHeight = 0;
            // REMOVED: getHolder().addCallback(mSHCallback);
            // REMOVED: getHolder().setType(SurfaceHolder.SURFACE_TYPE_PUSH_BUFFERS);
            Focusable = true;
            FocusableInTouchMode = true;
            RequestFocus();
            // REMOVED: mPendingSubtitleTracks = new Vector<Pair<InputStream, MediaFormat>>();
            mCurrentState = STATE_IDLE;
            mTargetState = STATE_IDLE;
        }

        public virtual IRenderView RenderView
        {
            set
            {
                if (mRenderView != null)
                {
                    if (mMediaPlayer != null)
                    {
                        mMediaPlayer.SetDisplay(null);
                    }

                    View renderUIView2 = mRenderView.View;
                    mRenderView.removeRenderCallback(mSHCallback);
                    mRenderView = null;
                    RemoveView(renderUIView2);
                }

                if (value == null)
                {
                    return;
                }

                mRenderView = value;
                value.AspectRatio = mCurrentAspectRatio;
                if (mVideoWidth > 0 && mVideoHeight > 0)
                {
                    value.setVideoSize(mVideoWidth, mVideoHeight);
                }
                if (mVideoSarNum > 0 && mVideoSarDen > 0)
                {
                    value.setVideoSampleAspectRatio(mVideoSarNum, mVideoSarDen);
                }

                View renderUIView = mRenderView.View;
                LayoutParams lp = new LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent, GravityFlags.Center);
                renderUIView.LayoutParameters = (lp);
                AddView(renderUIView);

                mRenderView.addRenderCallback(mSHCallback);
                mRenderView.VideoRotation = mVideoRotationDegree;
            }
        }

        public virtual int Render
        {
            set
            {
                switch (value)
                {
                    case RENDER_NONE:
                        RenderView = null;
                        break;
                    case RENDER_TEXTURE_VIEW:
                        {
                            TextureRenderView renderView = new TextureRenderView(Context);
                            if (mMediaPlayer != null)
                            {
                                renderView.SurfaceHolder.bindToMediaPlayer(mMediaPlayer);
                                renderView.setVideoSize(mMediaPlayer.VideoWidth, mMediaPlayer.VideoHeight);
                                renderView.setVideoSampleAspectRatio(mMediaPlayer.VideoSarNum, mMediaPlayer.VideoSarDen);
                                renderView.AspectRatio = mCurrentAspectRatio;
                            }
                            RenderView = renderView;
                            break;
                        }
                    case RENDER_SURFACE_VIEW:
                        {
                            SurfaceRenderView renderView = new SurfaceRenderView(Context);
                            RenderView = renderView;
                            break;
                        }
                    default:
                        Log.Error(TAG, string.Format("invalid render %d\n", value));
                        break;
                }
            }
        }

        /// <summary>
        /// Sets video path.
        /// </summary>
        /// <param name="path"> the path of the video. </param>
        public virtual string VideoPath
        {
            set
            {
                VideoURI = Uri.Parse(value);
            }
        }

        /// <summary>
        /// Sets video URI.
        /// </summary>
        /// <param name="uri"> the URI of the video. </param>
        public virtual Uri VideoURI
        {
            set
            {
                setVideoURI(value, null);
            }
        }

        /// <summary>
        /// Sets video URI using specific headers.
        /// </summary>
        /// <param name="uri">     the URI of the video. </param>
        /// <param name="headers"> the headers for the URI request.
        ///                Note that the cross domain redirection is allowed by default, but that can be
        ///                changed with key/value pairs through the headers parameter with
        ///                "android-allow-cross-domain-redirect" as the key and "0" or "1" as the value
        ///                to disallow or allow cross domain redirection. </param>
        private void setVideoURI(Uri uri, IDictionary<string, string> headers)
        {
            mUri = uri;
            mHeaders = headers;
            mSeekWhenPrepared = 0;
            openVideo();
            RequestLayout();
            Invalidate();
        }

        // REMOVED: addSubtitleSource
        // REMOVED: mPendingSubtitleTracks

        public virtual void stopPlayback()
        {
            if (mMediaPlayer != null)
            {
                mMediaPlayer.Stop();
                mMediaPlayer.Release();
                mMediaPlayer = null;
                mCurrentState = STATE_IDLE;
                mTargetState = STATE_IDLE;
                AudioManager am = (AudioManager)mAppContext.GetSystemService(Context.AudioService);
                am.AbandonAudioFocus(null);
            }
        }

        private void openVideo()
        {
            if (mUri == null || mSurfaceHolder == null)
            {
                // not ready for playback just yet, will try again later
                return;
            }
            // we shouldn't clear the target state, because somebody might have
            // called start() previously
            release(false);

            AudioManager am = (AudioManager)mAppContext.GetSystemService(Context.AudioService);
            am.RequestAudioFocus(null, Stream.Music, AudioFocus.Gain);

            try
            {
                if (usingAndroidPlayer)
                {
                    mMediaPlayer = new AndroidMediaPlayer();
                }
                else
                {
                    IjkMediaPlayer ijkMediaPlayer = null;
                    if (mUri != null)
                    {
                        ijkMediaPlayer = new IjkMediaPlayer();
                        //ijkMediaPlayer.native_setLogLevel(IjkMediaPlayer.IJK_LOG_DEBUG);

                        if (usingMediaCodec)
                        {
                            ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "mediacodec", 1);
                            if (usingMediaCodecAutoRotate)
                            {
                                ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "mediacodec-auto-rotate", 1);
                            }
                            else
                            {
                                ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "mediacodec-auto-rotate", 0);
                            }
                        }
                        else
                        {
                            ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "mediacodec", 0);
                        }

                        if (usingOpenSLES)
                        {
                            ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "opensles", 1);
                        }
                        else
                        {
                            ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "opensles", 0);
                        }

                        if (TextUtils.IsEmpty(pixelFormat))
                        {
                            ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "overlay-format", IjkMediaPlayer.SdlFccRv32);
                        }
                        else
                        {
                            ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "overlay-format", pixelFormat);
                        }
                        ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "framedrop", 1);
                        ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "start-on-prepared", 0);

                        ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryFormat, "http-detect-range-support", 0);
                        ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryFormat, "timeout", 10000000);
                        ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryFormat, "reconnect", 1);

                        ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryCodec, "skip_loop_filter", 48);
                    }
                    mMediaPlayer = ijkMediaPlayer;
                }

                if (enableBackgroundPlay)
                {
                    mMediaPlayer = new TextureMediaPlayer(mMediaPlayer);
                }

                // TODO: create SubtitleController in MediaPlayer, but we need
                // a context for the subtitle renderers
                //JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
                //ORIGINAL LINE: final android.content.Context context = getContext();
                Context context = Context;
                // REMOVED: SubtitleController

                // REMOVED: mAudioSession
                mMediaPlayer.SetOnPreparedListener(mPreparedListener);
                mMediaPlayer.SetOnVideoSizeChangedListener(mSizeChangedListener);
                mMediaPlayer.SetOnCompletionListener(mCompletionListener);
                mMediaPlayer.SetOnErrorListener(mErrorListener);
                mMediaPlayer.SetOnInfoListener(mInfoListener);
                mMediaPlayer.SetOnBufferingUpdateListener(mBufferingUpdateListener);
                mCurrentBufferPercentage = 0;
                if (Build.VERSION.SdkInt > Build.VERSION_CODES.IceCreamSandwich)
                {
                    mMediaPlayer.SetDataSource(mAppContext, mUri, mHeaders);
                }
                else
                {
                    mMediaPlayer.DataSource = mUri.ToString();
                }
                bindSurfaceHolder(mMediaPlayer, mSurfaceHolder);
                mMediaPlayer.SetAudioStreamType((int)Stream.Music);
                mMediaPlayer.SetScreenOnWhilePlaying(true);
                mMediaPlayer.PrepareAsync();

                // REMOVED: mPendingSubtitleTracks

                // we don't set the target state here either, but preserve the
                // target state that was there before.
                mCurrentState = STATE_PREPARING;
                attachMediaController();
            }
            catch (Java.IO.IOException ex)
            {
                Log.Warn(TAG, "Unable to open content: " + mUri, ex);
                mCurrentState = STATE_ERROR;
                mTargetState = STATE_ERROR;
                mErrorListener.OnError(mMediaPlayer, (int)MediaError.Unknown, 0);
                return;
            }
            catch (System.ArgumentException ex)
            {
                Log.Warn(TAG, "Unable to open content: " + mUri, ex);
                mCurrentState = STATE_ERROR;
                mTargetState = STATE_ERROR;
                mErrorListener.OnError(mMediaPlayer, (int)MediaError.Unknown, 0);
                return;
            }
            finally
            {
                // REMOVED: mPendingSubtitleTracks.clear();
            }
        }

        public virtual IMediaController MediaController
        {
            set
            {
                if (mMediaController != null)
                {
                    mMediaController.hide();
                }
                mMediaController = value;
                attachMediaController();
            }
        }

        private void attachMediaController()
        {
            if (mMediaPlayer != null && mMediaController != null)
            {
                mMediaController.SetMediaPlayer(this);
                View anchorView = this.Parent is View ? (View)this.Parent : this;
                mMediaController.SetAnchorView(anchorView);
                mMediaController.Enabled = InPlaybackState;
            }
        }

        internal IMediaPlayerOnVideoSizeChangedListener mSizeChangedListener  ;

        private class OnVideoSizeChangedListenerAnonymousInnerClass : Java.Lang.Object, IMediaPlayerOnVideoSizeChangedListener
        {
            public OnVideoSizeChangedListenerAnonymousInnerClass(IjkVideoView outer)
            {
                outerInstance = outer;
            }
            private IjkVideoView outerInstance;
            public void OnVideoSizeChanged(IMediaPlayer mp, int width, int height, int sarNum, int sarDen)
            {
                outerInstance.mVideoWidth = mp.VideoWidth;
                outerInstance.mVideoHeight = mp.VideoHeight;
                outerInstance.mVideoSarNum = mp.VideoSarNum;
                outerInstance.mVideoSarDen = mp.VideoSarDen;
                if (outerInstance.mVideoWidth != 0 && outerInstance.mVideoHeight != 0)
                {
                    if (outerInstance.mRenderView != null)
                    {
                        outerInstance.mRenderView.setVideoSize(outerInstance.mVideoWidth, outerInstance.mVideoHeight);
                        outerInstance.mRenderView.setVideoSampleAspectRatio(outerInstance.mVideoSarNum, outerInstance.mVideoSarDen);
                    }
                    // REMOVED: getHolder().setFixedSize(mVideoWidth, mVideoHeight);
                    outerInstance.RequestLayout();
                }
            }
        }

        internal IMediaPlayerOnPreparedListener mPreparedListener  ;

        private class OnPreparedListenerAnonymousInnerClass : Java.Lang.Object, IMediaPlayerOnPreparedListener
        {
            private IjkVideoView outerInstance;
            public OnPreparedListenerAnonymousInnerClass(IjkVideoView outer)
            {
                outerInstance = outer;
            }
            public void OnPrepared(IMediaPlayer mp)
            {
                outerInstance.mCurrentState = STATE_PREPARED;

                // Get the capabilities of the player for this stream
                // REMOVED: Metadata

                if (outerInstance.mOnPreparedListener != null)
                {
                    outerInstance.mOnPreparedListener.OnPrepared(outerInstance.mMediaPlayer);
                }
                if (outerInstance.mMediaController != null)
                {
                    outerInstance.mMediaController.Enabled = true;
                }
                outerInstance.mVideoWidth = mp.VideoWidth;
                outerInstance.mVideoHeight = mp.VideoHeight;

                long seekToPosition = outerInstance.mSeekWhenPrepared; // mSeekWhenPrepared may be changed after seekTo() call
                if (seekToPosition != 0)
                {
                    outerInstance.SeekTo((int)seekToPosition);
                }
                if (outerInstance.mVideoWidth != 0 && outerInstance.mVideoHeight != 0)
                {
                    //Log.i("@@@@", "video size: " + mVideoWidth +"/"+ mVideoHeight);
                    // REMOVED: getHolder().setFixedSize(mVideoWidth, mVideoHeight);
                    if (outerInstance.mRenderView != null)
                    {
                        outerInstance.mRenderView.setVideoSize(outerInstance.mVideoWidth, outerInstance.mVideoHeight);
                        outerInstance.mRenderView.setVideoSampleAspectRatio(outerInstance.mVideoSarNum, outerInstance.mVideoSarDen);
                        if (!outerInstance.mRenderView.shouldWaitForResize() || outerInstance.mSurfaceWidth == outerInstance.mVideoWidth && outerInstance.mSurfaceHeight == outerInstance.mVideoHeight)
                        {
                            // We didn't actually change the size (it was already at the size
                            // we need), so we won't get a "surface changed" callback, so
                            // start the video here instead of in the callback.
                            if (outerInstance.mTargetState == STATE_PLAYING)
                            {
                                outerInstance.Start();
                                if (outerInstance.mMediaController != null)
                                {
                                    outerInstance.mMediaController.show();
                                }
                            }
                            else if (!outerInstance.IsPlaying && (seekToPosition != 0 || outerInstance.CurrentPosition > 0))
                            {
                                if (outerInstance.mMediaController != null)
                                {
                                    // Show the media controls when we're paused into a video and make 'em stick.
                                    outerInstance.mMediaController.show(0);
                                }
                            }
                        }
                    }
                }
                else
                {
                    // We don't know the video size yet, but should start anyway.
                    // The video size might be reported to us later.
                    if (outerInstance.mTargetState == STATE_PLAYING)
                    {
                        outerInstance.Start();
                    }
                }
            }
        }

        private IMediaPlayerOnCompletionListener mCompletionListener  ;

        private class OnCompletionListenerAnonymousInnerClass : Java.Lang.Object, IMediaPlayerOnCompletionListener
        {
            private IjkVideoView outerInstance;
            public OnCompletionListenerAnonymousInnerClass(IjkVideoView outer)
            {
                outerInstance = outer;
            }
            public void OnCompletion(IMediaPlayer mp)
            {
                outerInstance.mCurrentState = STATE_PLAYBACK_COMPLETED;
                outerInstance.mTargetState = STATE_PLAYBACK_COMPLETED;
                if (outerInstance.mMediaController != null)
                {
                    outerInstance.mMediaController.hide();
                }
                if (outerInstance.mOnCompletionListener != null)
                {
                    outerInstance.mOnCompletionListener.OnCompletion(outerInstance.mMediaPlayer);
                }
            }
        }

        private IMediaPlayerOnInfoListener mInfoListener  ;

        private class OnInfoListenerAnonymousInnerClass : Java.Lang.Object, IMediaPlayerOnInfoListener
        {
            private IjkVideoView outerInstance;
            public OnInfoListenerAnonymousInnerClass(IjkVideoView outer)
            {
                outerInstance = outer;
            }

            public bool OnInfo(IMediaPlayer mp, int arg1, int arg2)
            {
                if (outerInstance.mOnInfoListener != null)
                {
                    outerInstance.mOnInfoListener.OnInfo(mp, arg1, arg2);
                }
                switch (arg1)
                {
                    case TV.Danmaku.Ijk.Media.Player.MediaPlayer.MediaInfoVideoRotationChanged:
                        outerInstance.mVideoRotationDegree = arg2;
                        Log.Debug(outerInstance.TAG, "MEDIA_INFO_VIDEO_ROTATION_CHANGED: " + arg2);
                        if (outerInstance.mRenderView != null)
                        {
                            outerInstance.mRenderView.VideoRotation = arg2;
                        }
                        break;
                }
                return true;
            }
        }

        private IMediaPlayerOnErrorListener mErrorListener;

        private class OnErrorListenerAnonymousInnerClass : Java.Lang.Object, IMediaPlayerOnErrorListener
        {
            private IjkVideoView outerInstance;
            public OnErrorListenerAnonymousInnerClass(IjkVideoView outer)
            {
                outerInstance = outer;
            }
            public bool OnError(IMediaPlayer mp, int framework_err, int impl_err)
            {
                Log.Debug(outerInstance.TAG, "Error: " + framework_err + "," + impl_err);
                outerInstance.mCurrentState = STATE_ERROR;
                outerInstance.mTargetState = STATE_ERROR;
                if (outerInstance.mMediaController != null)
                {
                    outerInstance.mMediaController.hide();
                }

                /* If an error handler has been supplied, use it and finish. */
                if (outerInstance.mOnErrorListener != null)
                {
                    if (outerInstance.mOnErrorListener.OnError(outerInstance.mMediaPlayer, framework_err, impl_err))
                    {
                        return true;
                    }
                }

                /* Otherwise, pop up an error dialog so the user knows that
				 * something bad has happened. Only try and pop up the dialog
				 * if we're attached to a window. When we're going away and no
				 * longer have a window, don't bother showing the user an error.
				 */
                if (outerInstance.WindowToken != null)
                {
                    Resources r = outerInstance.mAppContext.Resources;
                    string message = "Unknown error";

                    if (framework_err == (int)MediaError.NotValidForProgressivePlayback)
                    {
                        message = "Invalid progressive playback";
                    }

                    (new Android.App.AlertDialog.Builder(outerInstance.Context)).SetMessage(message).SetPositiveButton("error", new OnClickListenerAnonymousInnerClass(this))
                                   .SetCancelable(false).Show();
                }
                return true;
            }

            private class OnClickListenerAnonymousInnerClass : Java.Lang.Object, IDialogInterfaceOnClickListener
            {

                private readonly OnErrorListenerAnonymousInnerClass outerInstance;

                public OnClickListenerAnonymousInnerClass(OnErrorListenerAnonymousInnerClass outerInstance)
                {
                    this.outerInstance = outerInstance;
                }

                public void OnClick(IDialogInterface dialog, int whichButton)
                {
                    /* If we get here, there is no onError listener, so
                     * at least inform them that the video is over.
                     */
                    if (outerInstance.outerInstance.mOnCompletionListener != null)
                    {
                        outerInstance.outerInstance.mOnCompletionListener.OnCompletion(outerInstance.outerInstance.mMediaPlayer);
                    }
                }
            }
        }

        private IMediaPlayerOnBufferingUpdateListener mBufferingUpdateListener  ;

        private class OnBufferingUpdateListenerAnonymousInnerClass : Java.Lang.Object, IMediaPlayerOnBufferingUpdateListener
        {
            public OnBufferingUpdateListenerAnonymousInnerClass(IjkVideoView outer)
            {
                outerInstance = outer;
            }
            private IjkVideoView outerInstance;
            public void OnBufferingUpdate(IMediaPlayer mp, int percent)
            {
                outerInstance.mCurrentBufferPercentage = percent;
            }
        }

        /// <summary>
        /// Register a callback to be invoked when the media file
        /// is loaded and ready to go.
        /// </summary>
        /// <param name="l"> The callback that will be run </param>
        public virtual IMediaPlayerOnPreparedListener OnPreparedListener
        {
            set
            {
                mOnPreparedListener = value;
            }
        }

        /// <summary>
        /// Register a callback to be invoked when the end of a media file
        /// has been reached during playback.
        /// </summary>
        /// <param name="l"> The callback that will be run </param>
        public virtual IMediaPlayerOnCompletionListener OnCompletionListener
        {
            set
            {
                mOnCompletionListener = value;
            }
        }

        /// <summary>
        /// Register a callback to be invoked when an error occurs
        /// during playback or setup.  If no listener is specified,
        /// or if the listener returned false, VideoView will inform
        /// the user of any errors.
        /// </summary>
        /// <param name="l"> The callback that will be run </param>
        public virtual IMediaPlayerOnErrorListener OnErrorListener
        {
            set
            {
                mOnErrorListener = value;
            }
        }

        /// <summary>
        /// Register a callback to be invoked when an informational event
        /// occurs during playback or setup.
        /// </summary>
        /// <param name="l"> The callback that will be run </param>
        public virtual IMediaPlayerOnInfoListener OnInfoListener
        {
            set
            {
                mOnInfoListener = value;
            }
        }

        // REMOVED: mSHCallback
        private void bindSurfaceHolder(IMediaPlayer mp, IRenderView_ISurfaceHolder holder)
        {
            if (mp == null)
            {
                return;
            }

            if (holder == null)
            {
                mp.SetDisplay(null);
                return;
            }

            holder.bindToMediaPlayer(mp);
        }

        internal IRenderView_IRenderCallback mSHCallback = null;

        private class IRenderView_IRenderCallbackAnonymousInnerClass : Java.Lang.Object, IRenderView_IRenderCallback
        {
            private IjkVideoView outerInstance;
            public IRenderView_IRenderCallbackAnonymousInnerClass(IjkVideoView outer)
            {
                outerInstance = outer;
            }
            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: public void onSurfaceChanged(@NonNull IRenderView.ISurfaceHolder holder, int format, int w, int h)
            public void onSurfaceChanged(IRenderView_ISurfaceHolder holder, int format, int w, int h)
            {
                if (holder.RenderView != outerInstance.mRenderView)
                {
                    Log.Error(outerInstance.TAG, "onSurfaceChanged: unmatched render callback\n");
                    return;
                }

                outerInstance.mSurfaceWidth = w;
                outerInstance.mSurfaceHeight = h;
                bool isValidState = (outerInstance.mTargetState == STATE_PLAYING);
                bool hasValidSize = !outerInstance.mRenderView.shouldWaitForResize() || (outerInstance.mVideoWidth == w && outerInstance.mVideoHeight == h);
                if (outerInstance.mMediaPlayer != null && isValidState && hasValidSize)
                {
                    if (outerInstance.mSeekWhenPrepared != 0)
                    {
                        outerInstance.SeekTo((int)outerInstance.mSeekWhenPrepared);
                    }
                    outerInstance.Start();
                }
            }

            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: public void onSurfaceCreated(@NonNull IRenderView.ISurfaceHolder holder, int width, int height)
            public void onSurfaceCreated(IRenderView_ISurfaceHolder holder, int width, int height)
            {
                if (holder.RenderView != outerInstance.mRenderView)
                {
                    Log.Error(outerInstance.TAG, "onSurfaceCreated: unmatched render callback\n");
                    return;
                }

                outerInstance.mSurfaceHolder = holder;
                if (outerInstance.mMediaPlayer != null)
                {
                    outerInstance.bindSurfaceHolder(outerInstance.mMediaPlayer, holder);
                }
                else
                {
                    outerInstance.openVideo();
                }
            }

            //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
            //ORIGINAL LINE: public void onSurfaceDestroyed(@NonNull IRenderView.ISurfaceHolder holder)
            public void onSurfaceDestroyed(IRenderView_ISurfaceHolder holder)
            {
                if (holder.RenderView != outerInstance.mRenderView)
                {
                    Log.Error(outerInstance.TAG, "onSurfaceDestroyed: unmatched render callback\n");
                    return;
                }

                // after we return from this we can't use the surface any more
                outerInstance.mSurfaceHolder = null;
                // REMOVED: if (mMediaController != null) mMediaController.hide();
                // REMOVED: release(true);
                outerInstance.releaseWithoutStop();
            }
        }

        public virtual void releaseWithoutStop()
        {
            if (mMediaPlayer != null)
            {
                mMediaPlayer.SetDisplay(null);
            }
        }

        /*
		 * release the media player in any state
		 */
        public virtual void release(bool cleartargetstate)
        {
            if (mMediaPlayer != null)
            {
                mMediaPlayer.Reset();
                mMediaPlayer.Release();
                mMediaPlayer = null;
                // REMOVED: mPendingSubtitleTracks.clear();
                mCurrentState = STATE_IDLE;
                if (cleartargetstate)
                {
                    mTargetState = STATE_IDLE;
                }
                AudioManager am = (AudioManager)mAppContext.GetSystemService(Context.AudioService);
                am.AbandonAudioFocus(null);
            }
        }

        public override bool OnTouchEvent(MotionEvent ev)
        {
            if (InPlaybackState && mMediaController != null)
            {
                toggleMediaControlsVisiblity();
            }
            return false;
        }

        public override bool OnTrackballEvent(MotionEvent ev)
        {
            if (InPlaybackState && mMediaController != null)
            {
                toggleMediaControlsVisiblity();
            }
            return false;
        }
        public override bool OnKeyUp([GeneratedEnum] Keycode keyCode, KeyEvent @event)
        {

            bool isKeyCodeSupported = keyCode != Keycode.Back && keyCode != Keycode.VolumeUp && keyCode != Keycode.VolumeDown && keyCode != Keycode.VolumeMute && keyCode != Keycode.Menu && keyCode != Keycode.Call && keyCode != Keycode.Endcall;
            if (InPlaybackState && isKeyCodeSupported && mMediaController != null)
            {
                if (keyCode == Keycode.Headsethook || keyCode == Keycode.MediaPlayPause)
                {
                    if (mMediaPlayer.IsPlaying)
                    {
                        Pause();
                        mMediaController.show();
                    }
                    else
                    {
                        Start();
                        mMediaController.hide();
                    }
                    return true;
                }
                else if (keyCode == Keycode.MediaPlay)
                {
                    if (!mMediaPlayer.IsPlaying)
                    {
                        Start();
                        mMediaController.hide();
                    }
                    return true;
                }
                else if (keyCode == Keycode.MediaStop || keyCode == Keycode.MediaPause)
                {
                    if (mMediaPlayer.IsPlaying)
                    {
                        Pause();
                        mMediaController.show();
                    }
                    return true;
                }
                else
                {
                    toggleMediaControlsVisiblity();
                }
            }

            return base.OnKeyDown(keyCode, @event);
        }

        private void toggleMediaControlsVisiblity()
        {
            if (mMediaController.IsShowing)
            {
                mMediaController.hide();
            }
            else
            {
                mMediaController.show();
            }
        }

        public void Start()
        {
            if (InPlaybackState)
            {
                mMediaPlayer.Start();
                mCurrentState = STATE_PLAYING;
            }
            mTargetState = STATE_PLAYING;
        }

        public void Pause()
        {
            if (InPlaybackState)
            {
                if (mMediaPlayer.IsPlaying)
                {
                    mMediaPlayer.Pause();
                    mCurrentState = STATE_PAUSED;
                }
            }
            mTargetState = STATE_PAUSED;
        }

        public virtual void suspend()
        {
            release(false);
        }

        public virtual void resume()
        {
            openVideo();
        }

        public int Duration
        {
            get
            {
                if (InPlaybackState)
                {
                    return (int)mMediaPlayer.Duration;
                }

                return -1;
            }
        }

        public int CurrentPosition
        {
            get
            {
                if (InPlaybackState)
                {
                    return (int)mMediaPlayer.CurrentPosition;
                }
                return 0;
            }
        }

        public void SeekTo(int msec)
        {
            if (InPlaybackState)
            {
                mMediaPlayer.SeekTo(msec);
                mSeekWhenPrepared = 0;
            }
            else
            {
                mSeekWhenPrepared = msec;
            }
        }

        public bool IsPlaying
        {
            get
            {
                return InPlaybackState && mMediaPlayer.IsPlaying;
            }
        }

        public int BufferPercentage
        {
            get
            {
                if (mMediaPlayer != null)
                {
                    return mCurrentBufferPercentage;
                }
                return 0;
            }
        }

        private bool InPlaybackState
        {
            get
            {
                return (mMediaPlayer != null && mCurrentState != STATE_ERROR && mCurrentState != STATE_IDLE && mCurrentState != STATE_PREPARING);
            }
        }

        public bool CanPause()
        {
            return mCanPause;
        }

        public bool CanSeekBackward()
        {
            return mCanSeekBack;
        }

        public bool CanSeekForward()
        {
            return mCanSeekForward;
        }

        public int AudioSessionId
        {
            get
            {
                return 0;
            }
        }

        // REMOVED: getAudioSessionId();
        // REMOVED: onAttachedToWindow();
        // REMOVED: onDetachedFromWindow();
        // REMOVED: onLayout();
        // REMOVED: draw();
        // REMOVED: measureAndLayoutSubtitleWidget();
        // REMOVED: setSubtitleWidget();
        // REMOVED: getSubtitleLooper();

        //-------------------------
        // Extend: Aspect Ratio
        //-------------------------

        private static readonly int[] s_allAspectRatio = new int[] { IRenderView_Fields.AR_ASPECT_FIT_PARENT, IRenderView_Fields.AR_ASPECT_FILL_PARENT, IRenderView_Fields.AR_ASPECT_WRAP_CONTENT, IRenderView_Fields.AR_MATCH_PARENT, IRenderView_Fields.AR_16_9_FIT_PARENT, IRenderView_Fields.AR_4_3_FIT_PARENT };
        private int mCurrentAspectRatioIndex = 0;
        private int mCurrentAspectRatio;

        public virtual int toggleAspectRatio()
        {
            mCurrentAspectRatioIndex++;
            mCurrentAspectRatioIndex %= s_allAspectRatio.Length;

            mCurrentAspectRatio = s_allAspectRatio[mCurrentAspectRatioIndex];
            if (mRenderView != null)
            {
                mRenderView.AspectRatio = mCurrentAspectRatio;
            }
            return mCurrentAspectRatio;
        }

        //-------------------------
        // Extend: Render
        //-------------------------
        public const int RENDER_NONE = 0;
        public const int RENDER_SURFACE_VIEW = 1;
        public const int RENDER_TEXTURE_VIEW = 2;

        private IList<int> mAllRenders = new List<int>();
        private int mCurrentRenderIndex = 0;
        private int mCurrentRender = RENDER_NONE;

        private void initRenders()
        {
            mAllRenders.Clear();

            if (enableSurfaceView)
            {
                mAllRenders.Add(RENDER_SURFACE_VIEW);
            }
            if (enableTextureView && Build.VERSION.SdkInt >= Build.VERSION_CODES.IceCreamSandwich)
            {
                mAllRenders.Add(RENDER_TEXTURE_VIEW);
            }
            if (enableNoView)
            {
                mAllRenders.Add(RENDER_NONE);
            }

            if (mAllRenders.Count == 0)
            {
                mAllRenders.Add(RENDER_SURFACE_VIEW);
            }
            mCurrentRender = mAllRenders[mCurrentRenderIndex];
            Render = mCurrentRender;
        }

        public virtual int toggleRender()
        {
            mCurrentRenderIndex++;
            mCurrentRenderIndex %= mAllRenders.Count;

            mCurrentRender = mAllRenders[mCurrentRenderIndex];
            Render = mCurrentRender;
            return mCurrentRender;
        }


        //-------------------------
        // Extend: Background
        //-------------------------


        private void initBackground()
        {
            if (enableBackgroundPlay)
            {
                //            MediaPlayerService.intentToStart(getContext());
                //            mMediaPlayer = MediaPlayerService.getMediaPlayer();
            }
        }

        public virtual int AspectRatio
        {
            set
            {
                for (int i = 0; i < s_allAspectRatio.Length; i++)
                {
                    if (s_allAspectRatio[i] == value)
                    {
                        mCurrentAspectRatioIndex = i;
                        if (mRenderView != null)
                        {
                            mRenderView.AspectRatio = mCurrentAspectRatio;
                        }
                        break;
                    }
                }
            }
        }
    }


}