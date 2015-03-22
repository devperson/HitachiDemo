using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using ContosoBeacons.iOS.Renderers;
using ContosoBeacons.Controls;

[assembly: ExportRenderer(typeof(SwipedImage), typeof(SwipedImageRenderer))]
namespace ContosoBeacons.iOS.Renderers
{
    
    public class SwipedImageRenderer : ImageRenderer
    {
        UISwipeGestureRecognizer swipeGestureRecognizer;
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            swipeGestureRecognizer = new UISwipeGestureRecognizer(() => ((SwipedImage)Element).OnSwiped()) 
            { 
                Direction = UISwipeGestureRecognizerDirection.Left | UISwipeGestureRecognizerDirection.Right
            };
            if (e.NewElement == null)
            {
                if (swipeGestureRecognizer != null)
                {
                    this.RemoveGestureRecognizer(swipeGestureRecognizer);
                }
            }

            if (e.OldElement == null)
            {
                this.AddGestureRecognizer(swipeGestureRecognizer);
            }

            Control.UserInteractionEnabled = true;
        }
    }
}