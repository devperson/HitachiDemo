using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ContosoBeacons.Pages
{
    public partial class MarkLocationPage : ContentPage
    {
        public MarkLocationPage()
        {
            InitializeComponent();
            this.BindingContext = App.Locator.MenuVM.CurrentLocationData;

            btnSave.Clicked += (s, e) =>
                {
                    try
                    {
                        App.Locator.MenuVM.SaveLocation();
                        Navigation.PopAsync();
                    }
                    catch (Exception ex)
                    {
                        this.DisplayAlert("Error", ex.Message, "OK");
                    }
                };
        }
    }
}
