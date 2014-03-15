using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Controls;

namespace ATM_Navigator.View
{
    public class BasePage : PhoneApplicationPage
    {
        protected virtual void btnATM_Click(object sender, EventArgs e)
        {
            NavigationService.RemoveBackEntry();
            NavigationService.Navigate(new Uri("/View/ATMListPage.xaml", UriKind.Relative));
        }

        protected virtual void btnFilter_Click(object sender, EventArgs e)
        {
            NavigationService.RemoveBackEntry();
            NavigationService.Navigate(new Uri("/View/FiltersListPage.xaml", UriKind.Relative));
        }

        protected virtual void btnInfo_Click(object sender, EventArgs e)
        {
            NavigationService.RemoveBackEntry();
            NavigationService.Navigate(new Uri("/View/InformationPage.xaml", UriKind.Relative));
        }

        protected virtual void btnMap_Click(object sender, EventArgs e)
        {
            NavigationService.RemoveBackEntry();
            NavigationService.Navigate(new Uri("/View/MainPage.xaml", UriKind.Relative));
        }

        protected virtual void btnSettings_Click(object sender, EventArgs e)
        {
            NavigationService.RemoveBackEntry();
            NavigationService.Navigate(new Uri("/View/SettingsPage.xaml", UriKind.Relative));
        }

        public void SaveApplicationSettings(string key, object value)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;            
            settings[key] = value;
            settings.Save();            
        }

        public bool TryGetApplicationSettings(string key, out object value)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains(key))
            {
                value = settings[key];
                return true;                
            }
            value = null;
            return false;
        }
    }
}
