using System;
using System.Collections.Generic;
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

        private void SaveApplicationSettings()
        {
            base.SaveApplicationSettings("ATMList", (this.DataContext as ATMListPageViewModel).ATMList);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;            
            if (listBox.SelectedItem!=null)
            {
                (listBox.SelectedItem as ATM).IsChecked = !(listBox.SelectedItem as ATM).IsChecked;
                if (listBox.SelectedIndex == 0)
                {
                    if ((listBox.SelectedItem as ATM).IsChecked == true)
                    {
                        for (int i = 1; i < listBox.Items.Count(); i++)
                            (listBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).IsEnabled = false;       
                    }
                    else
                    {
                        for (int i = 1; i < listBox.Items.Count(); i++)
                            (listBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).IsEnabled = true;
                    }
                }
                (sender as ListBox).SelectedIndex = -1;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var cb = sender as CheckBox;
            //if (cb != null)
            //{
            //    var selectedItem = cb.DataContext;
            //    if ((selectedItem as ATM).Name == "Все банки")
            //    {
            //        if (!(selectedItem as ATM).IsChecked)
            //        {
            //            for (int i = 1; i < AtmListBox.Items.Count(); i++)
            //            {
            //                if (AtmListBox.ItemContainerGenerator.ContainerFromIndex(i) != null)
            //                {
            //                    (AtmListBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).IsEnabled = false;
            //                }
            //                else
            //                {
            //                    int qw = 12345;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            for (int i = 1; i < AtmListBox.Items.Count(); i++)
            //                (AtmListBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).IsEnabled = true;  
            //        }
            //    }
            //}
        }               
    }
}