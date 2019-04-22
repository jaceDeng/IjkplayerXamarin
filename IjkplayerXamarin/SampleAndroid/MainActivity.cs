using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace SampleAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Com.Shuyu.Gsyvideoplayer.Utils.OrientationUtils orientationUtils;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var player = FindViewById<Com.Shuyu.Gsyvideoplayer.Video.StandardGSYVideoPlayer>(Resource.Id.video_player);
            orientationUtils = new Com.Shuyu.Gsyvideoplayer.Utils.OrientationUtils(this, player);
            player.FullscreenButton.Click += (sender, e) =>
            {

                orientationUtils.ResolveByClick();
            };
           
            ImageView imageView = new ImageView(this);
            imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
            imageView.SetImageURI(Android.Net.Uri.Parse(" "));
            player.ThumbImageView = imageView;
            player.SetUp(" ", true, "测试");
            player.StartPlayLogic();

        }
    }
}