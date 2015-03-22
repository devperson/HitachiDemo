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
        public HomePage()
        {            
            this.Initialize();                       
        }

        private void Initialize()
        {            
            this.Master = new ContentPage { Content = new ListView { ItemsSource = new List<string> { "Mark Location", "Settings", "About" }, BackgroundColor = Color.Gray }, Title = "Menu" };
            this.Detail = new LandingPage();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }


    
}
