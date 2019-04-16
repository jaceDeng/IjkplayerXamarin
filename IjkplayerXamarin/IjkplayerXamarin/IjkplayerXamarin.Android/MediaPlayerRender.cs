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
using Xamarin.Forms.Platform.Android;
[assembly: Xamarin.Forms.ExportRenderer(typeof(IjkplayerXamarin.MediaPlayer), typeof(IjkplayerXamarin.Droid.MediaPlayerRender))]
namespace IjkplayerXamarin.Droid
{
    public class MediaPlayerRender : ViewRenderer<MediaPlayer, IjkVideoView>
    {
        public MediaPlayerRender(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<MediaPlayer> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                var frameLayout = new IjkVideoView(Context);
                frameLayout.VideoURI = Android.Net.Uri.Parse(Element.VideoURI);
                frameLayout.Start();
                if (e.NewElement != null)
                {
                  //  frameLayout.LayoutParameters = new FrameLayout.LayoutParams((int)e.NewElement.Width, (int)e.NewElement.Height);

                }
                SetNativeControl(frameLayout);
            }

        }
    }
}