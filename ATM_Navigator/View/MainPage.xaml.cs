using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using ATM_Navigator.ViewModel;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Shell;
using Newtonsoft.Json;
using ATM_Navigator.Model;
using System.Windows.Media.Imaging;
using System.Device.Location;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using System.Threading;

namespace ATM_Navigator.View
{
    public partial class MainPage : BasePage
    {       
        public MainPage()
        {
            InitializeComponent();
            InitFirstStart();
            DataContext = InitViewModel();
            InitMap();
            InitGeoLocation();
            GetATMList();
        }

        private void InitFirstStart()
        {
            object isFirstStart = true;
            if (!TryGetApplicationSettings("IsFirstStart", out isFirstStart))
            {
                SaveApplicationSettings("IsFirstStart", false);
                ShowSplashScreen();
            }
        }

        private void InitMap()
        {
            object uriFormatKey = null;
            if (TryGetApplicationSettings("MapType", out uriFormatKey))
            {
                Map.TileSources.Add(new CustomTileSource((string)uriFormatKey));
                return;
            }
            Map.TileSources.Add(new CustomTileSource(string.Empty));
        }

        private void InitGeoLocation()
        {
            object currentGeoPosition = null;
            if (TryGetApplicationSettings("CurrentGeoPosition", out currentGeoPosition))
            {
                Map.Center = currentGeoPosition as GeoCoordinate;
            }
            object toUseGPS = true;
            if (TryGetApplicationSettings("ToUseGPS", out toUseGPS))
            {
                if (!(bool)toUseGPS && Map.Center == null) Map.Center = new GeoCoordinate(53.54, 27.33);               
                return;
            }
            GetGeoLocation();
        }

        private BaseViewModel InitViewModel()
        {
             var viewModel = new MainPageViewModel();
             object zoomLevel = 0;
             if (TryGetApplicationSettings("ZoomLevel", out zoomLevel))
             {
                 viewModel.ZoomLevel = (int)zoomLevel;
             }
            return viewModel;
        }

        private void ShowSplashScreen()
        {
            this.IsHitTestVisible = false;
            ApplicationBar.IsVisible = false;
            ZoomInBtn.Visibility = Visibility.Collapsed;
            ZoomOutBtn.Visibility = Visibility.Collapsed;

            var popup = new Popup() { Height = 300, Width = 400, VerticalOffset = 100 };           
            var control = new PopUpUserControl();
            popup.Child = control;
            popup.IsOpen = true;
           
            control.btnOK.Click += (s, args) =>
            {
                popup.IsOpen = false;
                this.IsHitTestVisible = true;
                ApplicationBar.IsVisible = true;
                ZoomInBtn.Visibility = Visibility.Visible;
                ZoomOutBtn.Visibility = Visibility.Visible;
            };
        }              

        public async void GetGeoLocation()
        {
            var geolocator = new Windows.Devices.Geolocation.Geolocator { DesiredAccuracyInMeters = 500, ReportInterval = 500, MovementThreshold = 5};          
            try
            {
                var geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10)
                    );               
             //   Map.Center = new GeoCoordinate(geoposition.Coordinate.Latitude, geoposition.Coordinate.Longitude);
                //Map.Center = new GeoCoordinate(53.911517, 27.454244);
                //53° 53' 44.52'' N,27° 33' 11.33'' E
                Map.Center = new GeoCoordinate(53.8956996, 27.5531475);
                var overlay = new MapOverlay
                {
                    GeoCoordinate = Map.Center,
                    Content = new Image() { Source = new BitmapImage(new Uri("/Assets/marker-location.png", UriKind.Relative)), Margin = new Thickness(-15, -30, 0, 0) } 
                };               
                var layer = new MapLayer {overlay};
                Map.Layers.Add(layer);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Geolocation failed");
            }
        }

        private void GetATMList()
        {
            var client = new WebClient();
            var uriString = (this.DataContext as MainPageViewModel).ComposeUri();
            client.DownloadStringCompleted += webClient_DownloadStringCompleted;
            client.DownloadStringAsync(new Uri(uriString));
        }       

        void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (e.Result == "\"[]\"") return;
                var rootObjectsList = JsonConvert.DeserializeObject<List<RootObject>>(e.Result);
                foreach (var group in rootObjectsList.GroupBy(t => t.prov))
                {
                    var layer = new MapLayer();
                    var imageUri = string.Empty;
                    (this.DataContext as MainPageViewModel).AtmMappingDictionary.TryGetValue(group.First().prov, out imageUri);
                    foreach (var item in group)
                    {
                        var overlay = new MapOverlay
                        {
                            GeoCoordinate = new GeoCoordinate(item.lat, item.lng),
                            Content = new Image()
                            {
                                Source = new BitmapImage(new Uri(imageUri.Replace("Icons", "Markers"), UriKind.Relative)),
                                Margin = new Thickness(-15, -30, 0, 0)
                            }

                        };
                        layer.Add(overlay);
                    }
                    Map.Layers.Add(layer);
                }
            }
            catch (Exception) { }
        }       

        protected override void btnATM_Click(object sender, EventArgs e)
        {
            SaveMapSettings();
            base.btnATM_Click(sender, e);
        }

        protected override void btnFilter_Click(object sender, EventArgs e)
        {
            SaveMapSettings();
            base.btnFilter_Click(sender, e);
        }

        protected override void btnInfo_Click(object sender, EventArgs e)
        {
            SaveMapSettings();
            base.btnInfo_Click(sender, e);
        }

        protected override void btnSettings_Click(object sender, EventArgs e)
        {
            SaveMapSettings();
            base.btnSettings_Click(sender, e);
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            SaveMapSettings();
            NavigationService.RemoveBackEntry();           
            base.OnBackKeyPress(e);
        }

        private void SaveMapSettings()
        {
            base.SaveApplicationSettings("ZoomLevel", (this.DataContext as MainPageViewModel).ZoomLevel);
            base.SaveApplicationSettings("CurrentGeoPosition", Map.Center);
        }

        private void BasePage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            if (e.Orientation == PageOrientation.PortraitUp)
            {
                PortraitUpOrientationSet();
            }
            else
            {
                LandscapeOrientationSet();
            }
        }

        protected void PortraitUpOrientationSet()
        {
            ZoomPanel.Orientation = System.Windows.Controls.Orientation.Vertical;
            ZoomPanel.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            ZoomOutBtn.Margin = new Thickness(0, 0, 0, 80);
        }

        protected void LandscapeOrientationSet()
        {
            ZoomPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;
            ZoomPanel.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            ZoomOutBtn.Margin = new Thickness(0, 0, 80, 0);
        }
    }
}