using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Device.Location;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using ATM_Navigator.Model;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Maps.Toolkit;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Threading;

namespace ATM_Navigator.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {        
        private int zoomLevel = 15;
        public int ZoomLevel
        {
            get { return zoomLevel; }
            set
            {
                SetField(ref zoomLevel, value);                
            }
        }

        RelayCommand zoomInCommand;
        public ICommand ZoomInCommand
        {
            get
            {
                if (zoomInCommand == null)
                    zoomInCommand = new RelayCommand(OnZoomInCommand);
                return zoomInCommand;
            }
        }

        RelayCommand zoomOutCommand;
        public ICommand ZoomOutCommand
        {
            get
            {
                if (zoomOutCommand == null)
                    zoomOutCommand = new RelayCommand(OnZoomOutCommand);
                return zoomOutCommand;
            }
        }
        
        private void OnZoomInCommand()
        {
            ZoomLevel = Math.Min(ZoomLevel + 1, 20);
        }

        private void OnZoomOutCommand()
        {
            ZoomLevel= Math.Max(ZoomLevel -1, 1);
        }

        public string ComposeUri()
        {
            var strBuilder = new StringBuilder("http://atmnav-server.appspot.com/?");
            if (IsolatedStorageSettings.ApplicationSettings.Contains("FiltersList"))
            {
                var list = (List<Filter>)IsolatedStorageSettings.ApplicationSettings["FiltersList"];
                if (list != null)
                {
                    foreach (var item in list.Where(t => t.IsChecked).Select(t => t.Identifier))
                    {                       
                        strBuilder.AppendFormat("filters[]={0}", item);
                        strBuilder.Append("&");
                    }
                }
            }            
            if (IsolatedStorageSettings.ApplicationSettings.Contains("ATMList"))
            {
                var list = (List<ATM>)IsolatedStorageSettings.ApplicationSettings["ATMList"];
                if (list != null)
                {
                    foreach (var item in list.Where(t => t.IsChecked).Select(t => t.Identifier))
                    {                        
                        strBuilder.AppendFormat("objects[]={0}", item);
                        strBuilder.Append("&");
                    }
                }
            }
            var result = strBuilder.ToString();
            return result.EndsWith("&") ? result.Remove(result.Length -1, 1) : result;                    
        }

        public Dictionary<string, string> AtmMappingDictionary = new Dictionary<string, string>()
        {
            {"absolut", "../Assets/Markers/absolut.png"},
            {"alfa", "../Assets/Markers/alfa.png"},
            {"belagroprom", "../Assets/Markers/belagroprom.png"},
            {"belarus", "../Assets/Markers/belarus.png"},
            {"bve", "../Assets/Markers/bve.png"},
            {"belgazprom", "../Assets/Markers/belgazprom.png"},
            {"belinvest", "../Assets/Markers/belinvest.png"},
            {"bbmb", "../Assets/Markers/bbmb.png"},
            {"bnb", "../Assets/Markers/bnb.png"},
            {"belros", "../Assets/Markers/belros.png"},
            {"belswiss", "../Assets/Markers/belswiss.png"},
            {"bps", "../Assets/Markers/bps.png"},
            {"bta", "../Assets/Markers/bta.png"},
            {"vtb", "../Assets/Markers/vtb.png"},
            {"delta", "../Assets/Markers/delta.png"},
            {"euro", "../Assets/Markers/euro.png"},
            {"credex", "../Assets/Markers/credex.png"},
            {"mm", "../Assets/Markers/mm.png"},
            {"mtb", "../Assets/Markers/mtb.png"},
            {"paritet", "../Assets/Markers/paritet.png"},
            {"prior", "../Assets/Markers/prior.png"},
            {"rrb", "../Assets/Markers/rrb.png"},
            {"sbb", "../Assets/Markers/sbb.png"},
            {"techno", "../Assets/Markers/techno.png"},
            {"trust", "../Assets/Markers/trust.png"},
            {"fransa", "../Assets/Markers/fransa.png"},
            {"homecredit", "../Assets/Markers/homecredit.png"},
            {"zepter", "../Assets/Markers/zepter.png"}
        };
    }   
}
