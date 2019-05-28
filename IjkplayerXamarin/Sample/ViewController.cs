using Foundation;
using System;
using UIKit;

namespace Sample
{
    public partial class ViewController : UIViewController
    {
        public ViewController()
        {

        }

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.View.BackgroundColor = UIColor.Red;
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            this.NavigationController.PushViewController(new PlayerViewController(), true);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}