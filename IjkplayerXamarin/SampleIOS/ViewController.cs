using Foundation;
using Ijkplayer.iOS.UI;
using System;
using UIKit;

namespace IjkDemo
{
    public partial class ViewController : UIViewController
    {
        private ZFPlayerController player;

        private UIView containerView = new UIView() {
            BackgroundColor = UIColor.Orange,
            Frame = new CoreGraphics.CGRect(20,50,300,200)
        };

        private ZFPlayerControlView controlView = new ZFPlayerControlView();

        private UIButton playBtn = new UIButton() {
            BackgroundColor = UIColor.Red,
            Frame = new CoreGraphics.CGRect(20,270,80,40)
        };

        private UIButton changeBtn = new UIButton() {
            BackgroundColor = UIColor.Red,
            Frame = new CoreGraphics.CGRect(120,270,80,40)
        };

        private UIButton nextBtn = new UIButton() {
            BackgroundColor = UIColor.Red,
            Frame = new CoreGraphics.CGRect(220,270,80,40)
        };

        private NSUrl[] assetURLs = new NSUrl[] {
            new NSUrl ("https://www.apple.com/105/media/us/iphone-x/2017/01df5b43-28e4-4848-bf20-490c34a926a7/films/feature/iphone-x-feature-tpl-cc-us-20170912_1280x720h.mp4"),
            new NSUrl("https://www.apple.com/105/media/cn/mac/family/2018/46c4b917_abfd_45a3_9b51_4e3054191797/films/bruce/mac-bruce-tpl-cn-2018_1280x720h.mp4"),
            new NSUrl("https://www.apple.com/105/media/us/mac/family/2018/46c4b917_abfd_45a3_9b51_4e3054191797/films/peter/mac-peter-tpl-cc-us-2018_1280x720h.mp4"),
        };

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.View.AddSubview(this.containerView);

            this.playBtn.SetTitle("Play", UIControlState.Normal);
            this.View.AddSubview(this.playBtn);

            this.changeBtn.SetTitle("Change", UIControlState.Normal);
            this.View.AddSubview(this.changeBtn);

            this.nextBtn.SetTitle("Next", UIControlState.Normal);
            this.View.AddSubview(this.nextBtn);

            playBtn.TouchUpInside += PlayAction;
            changeBtn.TouchUpInside += ChangeAction;
            nextBtn.TouchUpInside += NextAction;

            ZIJKPlayerManager playerManager = new ZIJKPlayerManager();

            /// 播放器相关
            this.player = ZFPlayerController.PlayerWithPlayerManager(playerManager, this.containerView);
            this.player.ControlView = this.controlView;
        }

        void PlayAction(object sender, EventArgs e)
        {
            player.AssetURLs = this.assetURLs;
            player.PlayTheIndex(0);
        }

        void ChangeAction(object sender, EventArgs e)
        {
        }

        void NextAction(object sender, EventArgs e)
        {
            player.PlayTheNext();
        }
    }
}
