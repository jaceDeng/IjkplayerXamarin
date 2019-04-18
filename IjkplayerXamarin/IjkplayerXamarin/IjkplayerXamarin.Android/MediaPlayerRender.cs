using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Shuyu.Gsyvideoplayer.Video;
using Xamarin.Forms.Platform.Android;
[assembly: Xamarin.Forms.ExportRenderer(typeof(IjkplayerXamarin.MediaPlayer), typeof(IjkplayerXamarin.Droid.MediaPlayerRender))]
namespace IjkplayerXamarin.Droid
{
    public class MediaPlayerRender : ViewRenderer<MediaPlayer, StandardGSYVideoPlayer>
    {
        public MediaPlayerRender(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<MediaPlayer> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                var player = new StandardGSYVideoPlayer(Context);

                //设置返回按键功能

                if (e.OldElement != null)
                {
                    // Unsubscribe
                    //  frameLayout.Click -= FrameLayout_Touch;
                }
                if (e.NewElement != null)
                {
                    player.SetUp(Element.VideoURI, true, "");
                  //  player.StartPlayLogic();

                    // frameLayout.LayoutParameters = new FrameLayout.LayoutParams( , (int)e.NewElement.Height);
                    // frameLayout.Click += FrameLayout_Touch;
                }
                SetNativeControl(player);

                // frameLayout.SetUp(Element.VideoURI, true, "测试");
                //  frameLayout.StartPlayLogic();
            }

        }


    }
}