using ContosoBeacons.Models;
using Refractored.Xam.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoBeacons.ViewModels
{
    public class MenuListViewModel
    {
        public const string SETTINGS_KEY = "settings";

        public void LoadSettings()
        {
            CurrentSetting = new SettingData();
            CurrentSetting.Name = CrossSettings.Current.GetValueOrDefault<string>(SettingData.NAME);
            CurrentSetting.Beacon0 = CrossSettings.Current.GetValueOrDefault<string>(SettingData.B0);
            CurrentSetting.Beacon1 = CrossSettings.Current.GetValueOrDefault<string>(SettingData.B1);
            CurrentSetting.Beacon2 = CrossSettings.Current.GetValueOrDefault<string>(SettingData.B2);
            CurrentSetting.Beacon3 = CrossSettings.Current.GetValueOrDefault<string>(SettingData.B3);
            CurrentSetting.Beacon4 = CrossSettings.Current.GetValueOrDefault<string>(SettingData.B4);
        }

        public void LoadLocationData()
        {
        }

        public SettingData CurrentSetting { get; set; }
        public LocationData CurrentLocationData { get; set; }
        
        
        public void SaveCurrentSetting()
        {
            if (CurrentSetting != null)
            {
                if (CurrentSetting.Name.Length < 3)
                    throw new Exception("Name is too small. It should contains at least 3 chars.");
                if (CurrentSetting.Name.Length > 20)
                    throw new Exception("Name is too long. It can contains max 20 chars.");


                CrossSettings.Current.AddOrUpdateValue(SettingData.NAME, CurrentSetting.Name);
                CrossSettings.Current.AddOrUpdateValue(SettingData.B0, CurrentSetting.Beacon0);
                CrossSettings.Current.AddOrUpdateValue(SettingData.B1, CurrentSetting.Beacon1);
                CrossSettings.Current.AddOrUpdateValue(SettingData.B2, CurrentSetting.Beacon2);
                CrossSettings.Current.AddOrUpdateValue(SettingData.B3, CurrentSetting.Beacon3);
                CrossSettings.Current.AddOrUpdateValue(SettingData.B4, CurrentSetting.Beacon4);
            }
        }


        public void SaveLocation()
        {
            if (CurrentLocationData != null)
            {
                if (CurrentSetting.Name.Length < 3)
                    throw new Exception("Location is too small. It should contains at least 3 chars.");
                if (CurrentSetting.Name.Length > 40)
                    throw new Exception("Name is too long. It can contains max 40 chars.");
            }
        }
        
    }

    
}
