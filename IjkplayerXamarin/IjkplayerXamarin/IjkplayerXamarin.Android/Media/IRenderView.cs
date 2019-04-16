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

using Android.Views;
using TV.Danmaku.Ijk.Media.Player;

namespace IjkplayerXamarin.Droid
{


    public interface IRenderView
    {

        View View { get; }

        bool shouldWaitForResize();

        void setVideoSize(int videoWidth, int videoHeight);

        void setVideoSampleAspectRatio(int videoSarNum, int videoSarDen);

        int VideoRotation { set; }

        int AspectRatio { set; }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: void addRenderCallback(@NonNull IRenderCallback callback);
        void addRenderCallback(IRenderView_IRenderCallback callback);

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: void removeRenderCallback(@NonNull IRenderCallback callback);
        void removeRenderCallback(IRenderView_IRenderCallback callback);
    }

    public static class IRenderView_Fields
    {
        public const int AR_ASPECT_FIT_PARENT = 0;
        public const int AR_ASPECT_FILL_PARENT = 1;
        public const int AR_ASPECT_WRAP_CONTENT = 2;
        public const int AR_MATCH_PARENT = 3;
        public const int AR_16_9_FIT_PARENT = 4;
        public const int AR_4_3_FIT_PARENT = 5;
    }

    public interface IRenderView_ISurfaceHolder
    {
        void bindToMediaPlayer(IMediaPlayer mp);

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @NonNull IRenderView getRenderView();
        IRenderView RenderView { get; }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Nullable android.view.SurfaceHolder getSurfaceHolder();
        Android.Views.ISurfaceHolder SurfaceHolder { get; }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Nullable android.view.Surface openSurface();
        Surface openSurface();

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Nullable android.graphics.SurfaceTexture getSurfaceTexture();
        Android.Graphics.SurfaceTexture SurfaceTexture { get; }
    }

    public interface IRenderView_IRenderCallback
    {
        /// <param name="holder"> </param>
        /// <param name="width">  could be 0 </param>
        /// <param name="height"> could be 0 </param>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: void onSurfaceCreated(@NonNull IRenderView.ISurfaceHolder holder, int width, int height);
        void onSurfaceCreated(IRenderView_ISurfaceHolder holder, int width, int height);

        /// <param name="holder"> </param>
        /// <param name="format"> could be 0 </param>
        /// <param name="width"> </param>
        /// <param name="height"> </param>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: void onSurfaceChanged(@NonNull IRenderView.ISurfaceHolder holder, int format, int width, int height);
        void onSurfaceChanged(IRenderView_ISurfaceHolder holder, int format, int width, int height);

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: void onSurfaceDestroyed(@NonNull IRenderView.ISurfaceHolder holder);
        void onSurfaceDestroyed(IRenderView_ISurfaceHolder holder);
    }

}