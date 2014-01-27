using System;
using System.Collections.Generic;
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

        protected override void btnATM_Click(object sender, EventArgs e)
        {
            base.btnATM_Click(sender, e);
        }

        protected override void btnFilter_Click(object sender, EventArgs e)
        {
            base.btnFilter_Click(sender, e);
        }

        protected override void btnInfo_Click(object sender, EventArgs e)
        {
            base.btnInfo_Click(sender, e);
        }

        protected override void btnMap_Click(object sender, EventArgs e)
        {
            base.btnMap_Click(sender, e);
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