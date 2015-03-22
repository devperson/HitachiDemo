using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(ContosoBeacons.iOS.Renderers.NavigationPageRenderer))]
namespace ContosoBeacons.iOS.Renderers
{    
    public class NavigationPageRenderer : NavigationRenderer, IUIGestureRecognizerDelegate
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.InteractivePopGestureRecognizer.Delegate = this;
            this.WeakDelegate = new NavigationDelegate();
        }

        public override void PushViewController(UIViewController viewController, bool animated)
        {
            this.InteractivePopGestureRecognizer.Enabled = false;
            base.PushViewController(viewController, animated);
        }        
    }

    public class NavigationDelegate : UINavigationControllerDelegate
    {
        public override void DidShowViewController(UINavigationController navigationController, UIViewController viewController, bool animated)
        {
            navigationController.InteractivePopGestureRecognizer.Enabled = true;            
        }
    }
}