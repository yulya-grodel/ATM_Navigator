using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ATM_Navigator.ViewModel;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ATM_Navigator.View
{
    public partial class SettingsPage : BasePage
    {
        List<string> mapTypeItems = new List<string>() { "Open Streen Map", "Google Map" };

        public SettingsPage()
        {
            InitializeComponent();
            StateTextBlock.Text = "Включено";
            mapTypeList.ItemsSource = mapTypeItems;

            if (IsolatedStorageSettings.ApplicationSettings.Contains("ToUseGPS"))
            {
                var value = (bool)IsolatedStorageSettings.ApplicationSettings["ToUseGPS"];
                gpsSwitch.IsChecked = value;
                if (value) StateTextBlock.Text = "Включено";
                else StateTextBlock.Text = "Выключено";
            }
            if (IsolatedStorageSettings.ApplicationSettings.Contains("MapType"))
            {
                mapTypeList.SelectedIndex = mapTypeItems.IndexOf((string)IsolatedStorageSettings.ApplicationSettings["MapType"]);
            }
        }
           
        private void SaveApplicationSettings()
        {
            base.SaveApplicationSettings("MapType", mapTypeList.SelectedItem);
            base.SaveApplicationSettings("ToUseGPS", gpsSwitch.IsChecked);
        }

        private void ToggleSwitch_Checked(object sender, EventArgs e)
        {
            StateTextBlock.Text = "Включено";
        }

        private void ToggleSwitch_Unchecked(object sender, EventArgs e)
        {
            StateTextBlock.Text = "Выключено";
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            SaveApplicationSettings();
            NavigationService.RemoveBackEntry();
            NavigationService.Navigate(new Uri("/View/MainPage.xaml", UriKind.Relative));
           // base.OnBackKeyPress(e);
        }
    }
}