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
    public class HomePage : MasterDetailPage
    {
        //private bool showHome1 = true;
        //private ContentView middleContent = new ContentView();
        //private Grid popupLayout;
        //private Button btnLogo, btnMenu;
        //private GreyButton btnBenefit;
        //private SwipedImage imgOnPopup;

        public HomePage()
        {            
            this.Initialize();
            this.BindingContext = App.Locator.HomeViewModel;

            //btnMenu.Clicked += (s, e) =>
            //{
            //    if (popupLayout.TranslationX == -400)
            //        popupLayout.TranslateTo(0, 0);
            //    else popupLayout.TranslateTo(-400, 0);
            //};

            //btnLogo.Clicked += (s, e) =>
            //{
            //    showHome1 = !showHome1;
            //    middleContent.Content = this.GetMiddleContent();
            //};

            //btnBenefit.Clicked += (s, e) =>
            //{
            //    this.Navigation.PushAsync(new ScreensCarouselPage(1), true);
            //};

            //imgOnPopup.Swiped += (s, e) =>
            //    {
            //        if (popupLayout.TranslationX == 0)
            //            popupLayout.TranslateTo(-400, 0);
            //    };
        }

        private void Initialize()
        {
            //Grid mainLayout = new Grid();
            //mainLayout.RowSpacing = 0;
            //mainLayout.BackgroundColor = Color.White;
            //mainLayout.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            //mainLayout.RowDefinitions.Add(new RowDefinition());

            //mainLayout.Children.Add(this.GetTopContent(), 0, 0);
            //mainLayout.Children.Add(this.GetHomeContent(), 0, 1);

            //popupLayout = this.GetPopupContent();
            //mainLayout.Children.Add(popupLayout, 0, 1);
            //this.Content = mainLayout;

            this.Master = new ContentPage { Content = new ListView { ItemsSource = new List<string> { "Mark Location", "Settings", "About" } }, Title = "Menu" };
            this.Detail = new LandingPage();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        //private Grid GetHomeContent()
        //{
        //    Grid content = new Grid();
        //    content.RowDefinitions.Add(new RowDefinition());
        //    content.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
        //    //add middle content
        //    middleContent.Padding = new Thickness(5);
        //    middleContent.Content = this.GetMiddleContent();
        //    content.Children.Add(middleContent, 0, 0);
        //    //add bottom red buttons
        //    var footer = new ContentView();
        //    footer.Padding = new Thickness(5, 0, 5, 5);
        //    footer.Content = this.GetFooterContent();
        //    content.Children.Add(footer, 0, 1);

        //    return content;
        //}

        //private Grid GetTopContent()
        //{
        //    Grid topLayout = new Grid();
        //    topLayout.BackgroundColor = Color.Black;
        //    topLayout.HeightRequest = 50;
        //    topLayout.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(3) });
        //    topLayout.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
        //    topLayout.ColumnDefinitions.Add(new ColumnDefinition());
        //    topLayout.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
        //    topLayout.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
        //    topLayout.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(3) });

        //    btnMenu = new Button() { Image = Device.OnPlatform("menu.png", "menu.png", "Images/menu.png"), WidthRequest = 35 };
        //    topLayout.Children.Add(btnMenu, 1, 0);
        //    topLayout.Children.Add(new Image() { Source = ImageSource.FromFile(Device.OnPlatform("logo.png", "logo.png", "Images/logo.png")), WidthRequest = 15 }, 3, 0);
        //    btnLogo = new Button { Text = "Hitachi Consulting", TextColor = Color.White, FontSize = 12, HorizontalOptions = LayoutOptions.Center };
        //    topLayout.Children.Add(btnLogo, 4, 0);
        //    return topLayout;
        //}

        


        //private Grid GetPopupContent()
        //{
        //    Grid layout = new Grid() { TranslationX = -400 };
        //    layout.RowDefinitions.Add(new RowDefinition());
        //    layout.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
        //    layout.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
        //    layout.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

        //    imgOnPopup = new SwipedImage
        //    {
        //        Source = ImageSource.FromFile(Device.OnPlatform("popup.png", "popup.png", "Images/popup.png")),
        //        Aspect = Aspect.AspectFill,
        //        VerticalOptions = LayoutOptions.FillAndExpand,
        //        HorizontalOptions = LayoutOptions.FillAndExpand
        //    };

        //    layout.Children.Add(imgOnPopup, 0, 1, 0, 4);
        //    layout.Children.Add(new ContentView()
        //    {
        //        Padding = new Thickness(10, 5, 5, 5),
        //        Content = new Label()
        //        {
        //            Text = "Welcome back to the Hitachi Casino, Nathan.",
        //            TextColor = Color.White,
        //            FontSize = 25
        //        }
        //    }, 0, 1);
        //    layout.Children.Add(new ContentView()
        //    {
        //        Padding = new Thickness(10,5,5,10),
        //        Content = new Label()
        //        {
        //            Text = "Please proceed to the VIP services desk, located to the left as you enter the lobby.",
        //            TextColor = Color.White,
        //            FontSize = 14
        //        }
        //    }, 0, 2);

            
        //    btnBenefit = new GreyButton()
        //        {
        //            Text = "Find more VIP Benefits",
        //            FontSize = 12,
        //            TextColor = Color.Black,
        //            ImageName = "greyBtn.png",
        //            WidthRequest = 160,
        //            HeightRequest = 35
        //        };

        //    layout.Children.Add(new ContentView()
        //    {
        //        Padding = new Thickness(10, 5, 5, 10),
        //        HorizontalOptions = LayoutOptions.Start,
        //        Content = btnBenefit
        //    }, 0, 3);       

        //    return layout;
        //}

      

    }


    
}
