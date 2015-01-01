using ContosoBeacons.Pages;
using ContosoBeacons.ViewModels;
using System;
using Xamarin.Forms;

namespace ContosoBeacons
{
	public class App
	{
        public static ViewModelLocator Locator = new ViewModelLocator();
		public static Page GetMainPage ()
		{
            
            return new NavigationPage(new HomePage()) { };
		}
	}
}

