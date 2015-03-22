using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ContosoBeacons.Pages
{
    public partial class MenuListPage : ContentPage
    {
        private List<string> menuItems = new List<string> { "Mark Location", "Settings", "About" };
        public MenuListPage()
        {
            InitializeComponent();

            lvMenu.ItemsSource = menuItems;
            lvMenu.ItemSelected += (s, e) =>
                {
                    var selectedItem = e.SelectedItem.ToString();
                    if (selectedItem == menuItems[0])//location page
                    {
                        Navigation.PushAsync(new MarkLocationPage());
                    }
                    else if (selectedItem == menuItems[1]) //settings
                    {
                        Navigation.PushAsync(new SettingsPage());
                    }
                    else if (selectedItem == menuItems[2])
                    {
                        Navigation.PushAsync(new AboutPage());
                    }
                };
        }
    }
}
