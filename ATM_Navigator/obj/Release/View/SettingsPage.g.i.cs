﻿#pragma checksum "d:\Dropbox\ATM_Navigator\ATM_Navigator\View\SettingsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AEB463B698B36487242C13F4DEB44BD9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ATM_Navigator.View;
using Microsoft.Phone.Controls;
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
    
    
    public partial class SettingsPage : ATM_Navigator.View.BasePage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock StateTextBlock;
        
        internal Microsoft.Phone.Controls.ToggleSwitch gpsSwitch;
        
        internal Microsoft.Phone.Controls.ListPicker mapTypeList;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ATM%20Navigator;component/View/SettingsPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.StateTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("StateTextBlock")));
            this.gpsSwitch = ((Microsoft.Phone.Controls.ToggleSwitch)(this.FindName("gpsSwitch")));
            this.mapTypeList = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("mapTypeList")));
        }
    }
}

