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
        public MenuListPage()
        {
            InitializeComponent();

            lvMenu.ItemsSource = new List<string> { "Mark Location", "Settings", "About" };
        }
    }
}
