using System;
using System.ComponentModel;
using System.Drawing;
#if __UNIFIED__
using UIKit;
#elif __IOS__
using MonoTouch.UIKit;
#endif
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using ContosoBeacons.Controls;
using ContosoBeacons.iOS.Renderers;


[assembly: ExportRenderer(typeof(ImageButton), typeof(ImageButtonRenderer))]
namespace ContosoBeacons.iOS.Renderers
{
    using System.Threading.Tasks;

    /// <summary>
    /// Draws a button on the iOS platform with the image shown in the right 
    /// position with the right size.
    /// </summary>
    public partial class ImageButtonRenderer : ButtonRenderer
    {
        /// <summary>
        /// The padding to use in the control.
        /// </summary>
        private const int ControlPadding = 2;

        /// <summary>
        /// Identifies the iPad.
        /// </summary>
        private const string Ipad = "iPad";

        /// <summary>
        /// Gets the underlying element typed as an <see cref="CurrentImageButton"/>.
        /// </summary>
        private ImageButton CurrentImageButton
        {
            get { return (ImageButton)Element; }
        }

        /// <summary>
        /// Handles the initial drawing of the button.
        /// </summary>
        /// <param name="e">Information on the <see cref="CurrentImageButton"/>.</param> 
        protected async override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            var imageButton = this.CurrentImageButton;
            var targetButton = Control;
            if (imageButton != null && targetButton != null && imageButton.Source != null)
            {
                if (imageButton.HasLineBreak)
                {
                    targetButton.TitleLabel.LineBreakMode = UILineBreakMode.WordWrap | UILineBreakMode.TailTruncation;
                    targetButton.TitleLabel.Lines = 0;
                }
                
                await SetImageAsync(imageButton.Source, this.GetWidth(imageButton.ImageWidthRequest), this.GetHeight(imageButton.ImageHeightRequest), targetButton);

                switch (imageButton.Orientation)
                {
                    case ImageOrientation.ImageToLeft:
                        AlignToLeft(targetButton);
                        break;
                    case ImageOrientation.ImageToRight:
                        AlignToRight(imageButton.ImageWidthRequest, targetButton);
                        break;
                    case ImageOrientation.ImageOnTop:
                        AlignToTop(imageButton.ImageHeightRequest, imageButton.ImageWidthRequest, targetButton);
                        break;
                    case ImageOrientation.ImageOnBottom:
                        AlignToBottom(imageButton.ImageHeightRequest, imageButton.ImageWidthRequest, targetButton);
                        break;
                }
            }
        }

        /// <summary>
        /// Called when the underlying model's properties are changed.
        /// </summary>
        /// <param name="sender">Model sending the change event.</param>
        /// <param name="e">Event arguments.</param>
        protected async override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == ImageButton.SourceProperty.PropertyName)
            {
                var sourceButton = this.Element as ImageButton;
                if (sourceButton != null && sourceButton.Source != null)
                {
                    var imageButton = this.CurrentImageButton;
                    var targetButton = Control;
                    if (imageButton != null && targetButton != null && imageButton.Source != null)
                    {
                        await SetImageAsync(imageButton.Source, imageButton.ImageWidthRequest, imageButton.ImageHeightRequest, targetButton);
                    }
                }
            }
        }

        /// <summary>
        /// Properly aligns the title and image on a button to the left.
        /// </summary>
        /// <param name="targetButton">The button to align.</param>
        private static void AlignToLeft(UIButton targetButton)
        {
            targetButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            targetButton.TitleLabel.TextAlignment = UITextAlignment.Left;

            var titleInsets = new UIEdgeInsets(0, ControlPadding, 0, -1 * ControlPadding);
            targetButton.TitleEdgeInsets = titleInsets;
        }

        /// <summary>
        /// Properly aligns the title and image on a button to the right.
        /// </summary>
        /// <param name="widthRequest">The requested image width.</param>
        /// <param name="targetButton">The button to align.</param>
        private static void AlignToRight(int widthRequest, UIButton targetButton)
        {
            targetButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            targetButton.TitleLabel.TextAlignment = UITextAlignment.Right;

            var titleInsets = new UIEdgeInsets(0, 0, 0, widthRequest + ControlPadding);

            targetButton.TitleEdgeInsets = titleInsets;
            var imageInsets = new UIEdgeInsets(0, widthRequest, 0, -1 * widthRequest);
            targetButton.ImageEdgeInsets = imageInsets;
        }

        /// <summary>
        /// Properly aligns the title and image on a button when the image is over the title.
        /// </summary>
        /// <param name="heightRequest">The requested image height.</param>
        /// <param name="widthRequest">The requested image width.</param>
        /// <param name="targetButton">The button to align.</param>
        private void AlignToTop(int heightRequest, int widthRequest, UIButton targetButton)
        {
            targetButton.VerticalAlignment = UIControlContentVerticalAlignment.Top;
            targetButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            targetButton.TitleLabel.TextAlignment = UITextAlignment.Center;

            targetButton.TitleLabel.Text = "Microsoft";
            targetButton.SizeToFit();

            var titleWidth = targetButton.TitleLabel.IntrinsicContentSize.Width;

            UIEdgeInsets titleInsets;
            UIEdgeInsets imageInsets;

            if (UIDevice.CurrentDevice.Model.Contains(Ipad))
            {
                titleInsets = new UIEdgeInsets(heightRequest, Convert.ToInt32(-1 * widthRequest / 2), -1 * heightRequest, Convert.ToInt32(widthRequest / 2));
                imageInsets = new UIEdgeInsets(0, Convert.ToInt32(titleWidth / 2), 0, -1 * Convert.ToInt32(titleWidth / 2));
            }
            else
            {
                titleInsets = new UIEdgeInsets(heightRequest, Convert.ToInt32(-1 * widthRequest), -1 * heightRequest, Convert.ToInt32(widthRequest / 2));
                imageInsets = new UIEdgeInsets(0, titleWidth / 2, 0, -1 * titleWidth / 2);
            }
            //we hard code this UIEdgeInsets for Red buttons(in home page)
            targetButton.TitleEdgeInsets = new UIEdgeInsets(60, -38, 0, 0);
            if(CurrentImageButton.ImageEdgeInsets != Xamarin.Forms.Rectangle.Zero)
                targetButton.ImageEdgeInsets = new UIEdgeInsets((float)CurrentImageButton.ImageEdgeInsets.Left, (float)CurrentImageButton.ImageEdgeInsets.Top, (float)CurrentImageButton.ImageEdgeInsets.Right, (float)CurrentImageButton.ImageEdgeInsets.Bottom);
            else targetButton.ImageEdgeInsets = new UIEdgeInsets(0, 28, 0, 0);
        }

        /// <summary>
        /// Properly aligns the title and image on a button when the title is over the image.
        /// </summary>
        /// <param name="heightRequest">The requested image height.</param>
        /// <param name="widthRequest">The requested image width.</param>
        /// <param name="targetButton">The button to align.</param>
        private static void AlignToBottom(int heightRequest, int widthRequest, UIButton targetButton)
        {
            targetButton.VerticalAlignment = UIControlContentVerticalAlignment.Bottom;
            targetButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            targetButton.TitleLabel.TextAlignment = UITextAlignment.Center;
            targetButton.SizeToFit();
            var titleWidth = targetButton.TitleLabel.IntrinsicContentSize.Width;

            UIEdgeInsets titleInsets;
            UIEdgeInsets imageInsets;

            if (UIDevice.CurrentDevice.Model.Contains(Ipad))
            {
                titleInsets = new UIEdgeInsets(-1 * heightRequest, Convert.ToInt32(-1 * widthRequest / 2), heightRequest, Convert.ToInt32(widthRequest / 2));
                imageInsets = new UIEdgeInsets(0, titleWidth / 2, 0, -1 * titleWidth / 2);
            }
            else
            {
                titleInsets = new UIEdgeInsets(-1 * heightRequest, -1 * widthRequest, heightRequest, widthRequest);
                imageInsets = new UIEdgeInsets(0, 0, 0, 0);
            }

            targetButton.TitleEdgeInsets = titleInsets;
            targetButton.ImageEdgeInsets = imageInsets;
        }

        /// <summary>
        /// Loads an image from a bundle given the supplied image name, resizes it to the
        /// height and width request and sets it into a <see cref="UIButton"/>.
        /// </summary>
        /// <param name="source">The <see cref="ImageSource"/> to load the image from.</param>
        /// <param name="widthRequest">The requested image width.</param>
        /// <param name="heightRequest">The requested image height.</param>
        /// <param name="targetButton">A <see cref="UIButton"/> to set the image into.</param>
        /// <returns>A <see cref="Task"/> for the awaited operation.</returns>
        private async static Task SetImageAsync(ImageSource source, int widthRequest, int heightRequest, UIButton targetButton)
        {
            var handler = GetHandler(source);
            using (UIImage image = await handler.LoadImageAsync(source))
            {
                UIImage scaled = image;
                if (heightRequest > 0 && widthRequest > 0 && (image.Size.Height != heightRequest || image.Size.Width != widthRequest))
                {
                    scaled = scaled.Scale(new SizeF(widthRequest, heightRequest));
                }
                targetButton.SetImage(scaled.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal), UIControlState.Normal);
                //targetButton.SetImage(scaled.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal), UIControlState.Selected);
            }
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            if (CurrentImageButton.Orientation == ImageOrientation.ImageToRight)
            {
                var imageInsets = new UIEdgeInsets(0, Control.Frame.Size.Width - ControlPadding - CurrentImageButton.ImageWidthRequest, 0, 0);
                Control.ImageEdgeInsets = imageInsets;
            }
        }
    }
}