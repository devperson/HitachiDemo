﻿using ContosoBeacons.Models;
using ContosoBeacons.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContosoBeacons.Pages
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            App.Locator.MenuVM.LoadSettings();
            this.BindingContext = App.Locator.MenuVM.CurrentSetting;

            btnUpdate.Clicked += (s, e) =>
                {
                    try
                    {
                        App.Locator.MenuVM.SaveCurrentSetting();
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
