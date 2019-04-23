using Foundation;
using System;
using UIKit;
 using IJKPlayer;

namespace Sample
{
    public class PlayerViewController : UIViewController
    {
       private IJKFFMoviePlayerController iPlayer;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            IJKFFOptions options = IJKFFOptions.OptionsByDefault;

            this.iPlayer = new IJKFFMoviePlayerController(NSUrl.FromString("https://adaptivecardsblob.blob.core.windows.net/assets/AdaptiveCardsOverviewVideo.mp4"), options);
            this.iPlayer.View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            this.iPlayer.View.BackgroundColor = UIColor.White;
            this.iPlayer.View.Frame = new CoreGraphics.CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, 300);
            this.iPlayer.ScalingMode = IJKMPMovieScalingMode.AspectFit;
            this.iPlayer.ShouldAutoplay = true;
            this.View.AutosizesSubviews = true;
            this.View.AddSubview(this.iPlayer.View);
           // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.iPlayer?.PrepareToPlay();
            this.iPlayer?.Play();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
