using System;
using System.Collections.Generic;
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
    public partial class FiltersListPage : BasePage
    {
        public FiltersListPage()
        {
            InitializeComponent();
            DataContext = new FiltersListPageViewModel();
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
            base.SaveApplicationSettings("FiltersList", (this.DataContext as FiltersListPageViewModel).FiltersList);
        }
    }
}