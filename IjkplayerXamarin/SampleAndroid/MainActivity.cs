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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var player = FindViewById<Com.Shuyu.Gsyvideoplayer.Video.StandardGSYVideoPlayer>(Resource.Id.video_player);
            player.SetUp("http://vfx.mtime.cn/Video/2017/03/31/mp4/170331093811717750.mp4", true,"测试");
            player.StartPlayLogic();

        }
    }
}