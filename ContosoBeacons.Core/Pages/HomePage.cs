using ContosoBeacons.Controls;
using ContosoBeacons.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContosoBeacons.Pages
{
    public class HomePage : ContentPage
    {
        private bool showHome1 = true;
        private ContentView middleContent = new ContentView();
        private Grid popupLayout;
        private Button btnMenu, btnLogo;
        private GreyButton btnBenefit;
        private SwipedImage imgOnPopup;
        public HomePage()
        {            
            this.Initialize();
            this.BindingContext = App.Locator.HomeViewModel;

            btnMenu.Clicked += (s, e) =>
            {
                if (popupLayout.TranslationX == -400)
                    popupLayout.TranslateTo(0, 0);
                else popupLayout.TranslateTo(-400, 0);
            };

            btnLogo.Clicked += (s, e) =>
            {
                showHome1 = !showHome1;
                middleContent.Content = this.GetMiddleContent();
            };

            btnBenefit.Clicked += (s, e) =>
                {
                    this.Navigation.PushAsync(new ScreensCarouselPage(1), true);
                };

            imgOnPopup.Swiped += (s, e) =>
                {
                    if (popupLayout.TranslationX == 0)
                        popupLayout.TranslateTo(-400, 0);
                };
        }

        private void Initialize()
        {   
            Grid mainLayout = new Grid();
            mainLayout.RowSpacing = 0;
            mainLayout.BackgroundColor = Color.White;
            mainLayout.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            mainLayout.RowDefinitions.Add(new RowDefinition());

            mainLayout.Children.Add(this.GetTopContent(), 0, 0);
            mainLayout.Children.Add(this.GetHomeContent(), 0, 1);

            popupLayout = this.GetPopupContent();
            mainLayout.Children.Add(popupLayout, 0, 1);
            this.Content = mainLayout;
            
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private Grid GetHomeContent()
        {
            Grid content = new Grid();
            content.RowDefinitions.Add(new RowDefinition());
            content.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            //add middle content
            middleContent.Padding = new Thickness(5);
            middleContent.Content = this.GetMiddleContent();
            content.Children.Add(middleContent, 0, 0);
            //add bottom red buttons
            var footer = new ContentView();
            footer.Padding = new Thickness(5, 0, 5, 5);
            footer.Content = this.GetFooterContent();
            content.Children.Add(footer, 0, 1);

            return content;
        }

        private Grid GetTopContent()
        {
            Grid topLayout = new Grid();
            topLayout.BackgroundColor = Color.Black;
            topLayout.HeightRequest = 50;
            topLayout.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(3) });
            topLayout.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            topLayout.ColumnDefinitions.Add(new ColumnDefinition());
            topLayout.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            topLayout.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            topLayout.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(3) });

            btnMenu = new Button() { Image = Device.OnPlatform("menu.png", "menu.png", "Images/menu.png"), WidthRequest = 35 };
            topLayout.Children.Add(btnMenu, 1, 0);
            topLayout.Children.Add(new Image() { Source = ImageSource.FromFile(Device.OnPlatform("logo.png", "logo.png", "Images/logo.png")), WidthRequest = 15 }, 3, 0);
            btnLogo = new Button { Text = "Hitachi Consulting", TextColor = Color.White, FontSize = 12, HorizontalOptions = LayoutOptions.Center };
            topLayout.Children.Add(btnLogo, 4, 0);
            return topLayout;
        }

        private View GetMiddleContent()
        {
            if (showHome1)
                return new Image { Source = ImageSource.FromFile(Device.OnPlatform("bg.png", "bg.png", "Images/bg.png")), Aspect = Aspect.Fill, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            else
            {
                Grid contentLayout = new Grid();
                contentLayout.RowSpacing = 0;
                contentLayout.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                contentLayout.RowDefinitions.Add(new RowDefinition());
                contentLayout.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                contentLayout.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                contentLayout.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                contentLayout.Children.Add(new ContentView()
                {
                    Padding = new Thickness(4, 2, 0, 4),
                    Content = new Label()
                    {
                        Text = "Welcome back, Nathan.",
                        TextColor = Color.Black,
                        FontSize = 13
                    }
                }, 0, 0);
                contentLayout.Children.Add(new Image
                {
                    Source = ImageSource.FromFile(Device.OnPlatform("bg2.png", "bg2.png", "Images/bg2.png")),
                    Aspect = Aspect.AspectFill,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                }, 0, 1, 1, 5);

                contentLayout.Children.Add(new ContentView()
                {
                    Padding = new Thickness(7, 0, 5, 0),
                    Content = new Label()
                    {
                        Text = "Susan Anderson",
                        TextColor = Color.Black,
                        FontSize = 30
                    }
                }, 0, 2);
                contentLayout.Children.Add(new ContentView()
                {
                    Padding = new Thickness(7, 0, 5, 0),
                    Content = new Label()
                    {
                        Text = "is your VIP Liaison for the duration of your stay.",
                        TextColor = Color.Black,
                        FontSize = 13
                    }
                }, 0, 3);                
                Grid servicesLayout = new Grid();
                
                servicesLayout.Padding = new Thickness(5);
                //servicesLayout.Padding = new Thickness(7, 0, 0, 0);
                servicesLayout.Children.AddHorizontal(CreateMiddleButton(" Call Sussan\n directly", "call.png"));
                servicesLayout.Children.AddHorizontal(CreateMiddleButton(" Chat with\n Sussan", "chat.png"));
                servicesLayout.Children.AddHorizontal(CreateMiddleButton(" Schedule\n Activities", "calendar.png"));
                contentLayout.Children.Add(servicesLayout, 0, 4);

                return contentLayout;
            }
        }

        private Grid GetFooterContent()
        {
            Grid footerLayout = new Grid();
            footerLayout.RowSpacing = 7;
            footerLayout.ColumnSpacing = 7;
            footerLayout.ColumnDefinitions.Add(new ColumnDefinition());
            footerLayout.ColumnDefinitions.Add(new ColumnDefinition());
            footerLayout.ColumnDefinitions.Add(new ColumnDefinition());
            footerLayout.RowDefinitions.Add(new RowDefinition());
            footerLayout.RowDefinitions.Add(new RowDefinition());
            footerLayout.HeightRequest = 200;
            footerLayout.Children.Add(this.CreateFooterButton("My Account", 0, "account.png"), 0, 1, 0, 1);
            footerLayout.Children.Add(this.CreateFooterButton("VIP Club", 1, "vip.png"), 1, 2, 0, 1);
            footerLayout.Children.Add(this.CreateFooterButton("Reservations", 2, "reservation.png"), 2, 3, 0, 1);
            footerLayout.Children.Add(this.CreateFooterButton("Favorites", 3, "favorate.png"), 0, 1, 1, 2);
            footerLayout.Children.Add(this.CreateFooterButton("Messages", 4, "msg.png"), 1, 2, 1, 2);
            footerLayout.Children.Add(this.CreateFooterButton("Gift Cards", 5, "gift.png"), 2, 3, 1, 2);
            return footerLayout;
        }


        private Grid GetPopupContent()
        {
            Grid layout = new Grid() { TranslationX = -400 };
            layout.RowDefinitions.Add(new RowDefinition());
            layout.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            layout.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            layout.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

            imgOnPopup = new SwipedImage
            {
                Source = ImageSource.FromFile(Device.OnPlatform("popup.png", "popup.png", "Images/popup.png")),
                Aspect = Aspect.AspectFill,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            layout.Children.Add(imgOnPopup, 0, 1, 0, 4);
            layout.Children.Add(new ContentView()
            {
                Padding = new Thickness(10, 5, 5, 5),
                Content = new Label()
                {
                    Text = "Welcome back to the Hitachi Casino, Nathan.",
                    TextColor = Color.White,
                    FontSize = 25
                }
            }, 0, 1);
            layout.Children.Add(new ContentView()
            {
                Padding = new Thickness(10,5,5,10),
                Content = new Label()
                {
                    Text = "Please proceed to the VIP services desk, located to the left as you enter the lobby.",
                    TextColor = Color.White,
                    FontSize = 14
                }
            }, 0, 2);

            
            btnBenefit = new GreyButton()
                {
                    Text = "Find more VIP Benefits",
                    FontSize = 12,
                    TextColor = Color.Black,
                    ImageName = "greyBtn.png",
                    WidthRequest = 160,
                    HeightRequest = 35
                };

            layout.Children.Add(new ContentView()
            {
                Padding = new Thickness(10, 5, 5, 10),
                HorizontalOptions = LayoutOptions.Start,
                Content = btnBenefit
            }, 0, 3);       

            return layout;
        }

        private View CreateFooterButton(string text, int index, string imageName)//, double imgHeight, double imgWidth)
        {
            Grid panel = new Grid() { BackgroundColor = Color.Red, Padding = new Thickness(0, 10, 0, 0) };
            var button = new ImageButton
            {
                ImageHeightRequest = 40,
                ImageWidthRequest = 40,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = ImageOrientation.ImageOnTop,
                Text = text,
                FontSize = 13,
                TextColor = Color.White,
                BackgroundColor = Color.Transparent,
                Source = ImageSource.FromFile(imageName)
            };

            var backgroundButton = new ImageButton //Fix. There is no way to remove pressed state on button
            {
                ImageHeightRequest = 40,
                ImageWidthRequest = 40,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = ImageOrientation.ImageOnTop,
                Text = text,
                FontSize = 13,
                TextColor = Color.White,
                BackgroundColor = Color.Transparent,
                Source = ImageSource.FromFile(imageName),
                Opacity = 0.7
            };
            
            button.Clicked += (s, e) =>
            {
                this.Navigation.PushAsync(new ScreensCarouselPage(index), true);                
            };

            if (text.StartsWith("My") || text.StartsWith("Gift"))
            {
                button.ImageEdgeInsets = new Rectangle(0, 28, 0, 0);
                backgroundButton.ImageEdgeInsets = new Rectangle(0, 28, 0, 0);
            }
            panel.Children.Add(backgroundButton, 0, 0);
            panel.Children.Add(button, 0, 0);
            
            return panel;
        }
        
        private ImageButton CreateMiddleButton(string text, string imageName)
        {
            return new ImageButton()
                        {
                            Source = ImageSource.FromFile(imageName),
                            Orientation = ImageOrientation.ImageToLeft,
                            Font = Font.SystemFontOfSize(10),
                            ImageHeightRequest = 20,
                            ImageWidthRequest = 20,
                            TextColor = Color.Black,
                            Text = text,
                            HasLineBreak = true
                        };
        }

    }


    public class SwipedImage : Image 
    {
        public event EventHandler Swiped;
        public void OnSwiped()
        {
            if (Swiped != null)
                Swiped(null, null);
        }
    }
}
