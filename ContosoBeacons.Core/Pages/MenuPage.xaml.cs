using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoBeacons.Pages
{
    public partial class MenuPage
    {
        public MenuPage()
        {
            InitializeComponent();
            lvMenu.ItemsSource = new List<string> { "Mark Location", "Settings", "About" };
        }
    }
}
