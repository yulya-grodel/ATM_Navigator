using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace ATM_Navigator.View
{
    public partial class InformationPage : BasePage
    {
        public InformationPage()
        {
            InitializeComponent();
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {        
            NavigationService.RemoveBackEntry();                    
            NavigationService.Navigate(new Uri("/View/MainPage.xaml", UriKind.Relative));           
        }

        private void btnResponse_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.Subject = "ATM Navigator";
            emailComposeTask.Body = "";
            emailComposeTask.To = "yulya.grodel@gmail.com";
            emailComposeTask.Cc = "";
            emailComposeTask.Bcc = "";

            emailComposeTask.Show();
        }
    }
}