using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using ATM_Navigator.Model;
using ATM_Navigator.ViewModel;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace ATM_Navigator.View
{
    public partial class ATMListPage : BasePage
    {
        public ATMListPage()
        {
            InitializeComponent();
            DataContext = new ATMListPageViewModel();
            AtmListBox.LayoutUpdated += listBox_LayoutUpdated;
        }

        protected override void btnATM_Click(object sender, EventArgs e)
        {
            SaveApplicationSettings();
            base.btnATM_Click(sender, e);
        }

        protected override void btnFilter_Click(object sender, EventArgs e)
        {
            SaveApplicationSettings();
            base.btnFilter_Click(sender, e);
        }

        protected override void btnInfo_Click(object sender, EventArgs e)
        {
            SaveApplicationSettings();
            base.btnInfo_Click(sender, e);
        }

        protected override void btnMap_Click(object sender, EventArgs e)
        {
            SaveApplicationSettings();
            base.btnMap_Click(sender, e);
        }

        protected override void btnSettings_Click(object sender, EventArgs e)
        {
            SaveApplicationSettings();
            base.btnSettings_Click(sender, e);
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            SaveApplicationSettings();
            NavigationService.RemoveBackEntry();
            NavigationService.Navigate(new Uri("/View/MainPage.xaml", UriKind.Relative));
            // base.OnBackKeyPress(e);
        }

        private void SaveApplicationSettings()
        {
            base.SaveApplicationSettings("ATMList", (this.DataContext as ATMListPageViewModel).ATMList);         
        }      

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AtmListBox.SelectedItem != null)
            {
                (AtmListBox.SelectedItem as ATM).IsChecked = !(AtmListBox.SelectedItem as ATM).IsChecked;              
                (sender as ListBox).SelectedIndex = -1;
            }
        }

        private void listBox_LayoutUpdated(object sender, EventArgs e)
        {                   
            for (int i = 1; i < AtmListBox.Items.Count(); i++)
            {
                if (AtmListBox.ItemContainerGenerator.ContainerFromIndex(i) != null)
                {
                    (AtmListBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).IsEnabled = !(AtmListBox.Items[0] as ATM).IsChecked;
                }
            }            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SetListBoxItemsEnability((bool)(sender as CheckBox).IsChecked);             
        }

        private void SetListBoxItemsEnability(bool isChecked)
        {  
            for (int i = 1; i < AtmListBox.Items.Count(); i++)
            {
                if (AtmListBox.ItemContainerGenerator.ContainerFromIndex(i) == null) break;
                (AtmListBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).IsEnabled = !isChecked;
            }            
        }

    
    }
}