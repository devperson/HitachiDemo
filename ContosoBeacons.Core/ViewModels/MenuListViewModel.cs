using ContosoBeacons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoBeacons.ViewModels
{
    public class MenuListViewModel
    {
        public SettingData SettingFromCache
        {
            get
            {
                return null;
            }
        }

        public SettingData CurrentSetting { get; set; }
        public LocationData CurrentLocationData { get; set; }
        
        
        public void SaveCurrentSetting()
        {
            if(CurrentSetting!=null)
            {
                if (CurrentSetting.Name.Length < 3)
                    throw new Exception("Name is too small. It should contains at least 3 chars.");
                if (CurrentSetting.Name.Length > 20)
                    throw new Exception("Name is too long. It can contains max 20 chars.");
                
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
