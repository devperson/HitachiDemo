using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoBeacons.Models
{
    public class SettingData
    {
        public string Name { get; set; }
        public string Beacon0 { get; set; }
        public string Beacon1 { get; set; }
        public string Beacon2 { get; set; }
        public string Beacon3 { get; set; }
        public string Beacon4 { get; set; }

        public const string NAME = "N";
        public const string B0 = "B0";
        public const string B1 = "B1";
        public const string B2 = "B2";
        public const string B3 = "B3";
        public const string B4 = "B4";
    }
}
