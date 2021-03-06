﻿using ContosoBeacons.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContosoBeacons.Pages
{
    public partial class LandingPage : ContentPage
    {
        private bool showHome = true;
        public LandingPage()
        {
            InitializeComponent();
            
            this.SetupFooterContent();
            middleContent.Content = this.GetMiddleContent();
        }

        public void btnLogo_Clicked(object sender, EventArgs e)
        {
            showHome = !showHome;
            middleContent.Content = this.GetMiddleContent();
        }

        public void btnMenu_Clicked(object sender, EventArgs e)
        {
            var masterDetail = this.Parent as MasterDetailPage;
            masterDetail.IsPresented = !masterDetail.IsPresented;

            //this.Navigation.PushAsync(new PopupScreen());
        }

        private void SetupFooterContent()
        {            
            footerLayout.Children.Add(this.CreateFooterButton("My Account", 0, "account.png"), 0, 1, 0, 1);
            footerLayout.Children.Add(this.CreateFooterButton("VIP Club", 1, "vip.png"), 1, 2, 0, 1);
            footerLayout.Children.Add(this.CreateFooterButton("Reservations", 2, "reservation.png"), 2, 3, 0, 1);
            footerLayout.Children.Add(this.CreateFooterButton("Favorites", 3, "favorate.png"), 0, 1, 1, 2);
            footerLayout.Children.Add(this.CreateFooterButton("Messages", 4, "msg.png"), 1, 2, 1, 2);
            footerLayout.Children.Add(this.CreateFooterButton("Gift Cards", 5, "gift.png"), 2, 3, 1, 2);         
        }

        private View GetMiddleContent()
        {
            if (showHome)
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
                switch(index)
                {
                    case 0:
                        this.Navigation.PushAsync(new ScreenPage1(), true);
                        break;
                    case 1:
                        this.Navigation.PushAsync(new ScreenPage2(), true);
                        break;
                    case 2:
                        this.Navigation.PushAsync(new ScreenPage3(), true);
                        break;
                    case 3:
                        this.Navigation.PushAsync(new ScreenPage4(), true);
                        break;
                    case 4:
                        this.Navigation.PushAsync(new ScreenPage5(), true);
                        break;
                    case 5:
                        this.Navigation.PushAsync(new ScreenPage6(), true);
                        break;
                }
                //this.Navigation.PushAsync(new ScreensCarouselPage(index), true);
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
}
