using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using HitachiDemo.Controls;
using Xamarin.Forms;
using HitachiDemo.iOS.Renderers;

[assembly: ExportRenderer(typeof(GreyButton), typeof(GreyButtonRenderer))]
namespace HitachiDemo.iOS.Renderers
{
    public class GreyButtonRenderer : ButtonRenderer
	{
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var image = UIImage.FromBundle((Element as GreyButton).ImageName).CreateResizableImage(new UIEdgeInsets(5, 5, 5, 5));
                var native = Control as UIButton;
                native.SetBackgroundImage(image, UIControlState.Normal);
            }
        }
    }
}