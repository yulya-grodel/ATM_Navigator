﻿#pragma checksum "d:\DropBox\ATM_Navigator\ATM_Navigator\View\FiltersListPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7A878B98691B7CF0BD2B91265BFF4FFC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ATM_Navigator.View;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace ATM_Navigator.View {
    
    
    public partial class FiltersListPage : ATM_Navigator.View.BasePage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton btnMap;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton btnATM;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton btnFilter;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton btnInfo;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/ATM_Navigator;component/View/FiltersListPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.btnMap = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("btnMap")));
            this.btnATM = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("btnATM")));
            this.btnFilter = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("btnFilter")));
            this.btnInfo = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("btnInfo")));
        }
    }
}

