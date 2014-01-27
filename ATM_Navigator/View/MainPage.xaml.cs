using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ATM_Navigator.ViewModel;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Shell;
using ATM_Navigator.Resources;
using Newtonsoft.Json;
using ATM_Navigator.Model;
using System.Windows.Media.Imaging;
using System.Device.Location;
using System.Windows.Shapes;
using System.Windows.Media;
using ATM_Navigator.Helper;

namespace ATM_Navigator.View
{
    public partial class MainPage : BasePage
    {
        public MainPage()
        {
            InitializeComponent();                  
            DataContext = new MainPageViewModel();
            Map.TileSources.Add(new OpenStreetTileSource());
            GetGeoLocation();
            GetATMList();
        }

        public async void GetGeoLocation()
        {
            var geolocator = new Windows.Devices.Geolocation.Geolocator { DesiredAccuracyInMeters = 50 };          
            try
            {               
                //var geoposition = await geolocator.GetGeopositionAsync(
                //    maximumAge: TimeSpan.FromMinutes(5),
                //    timeout: TimeSpan.FromSeconds(10)
                //    );
                //Map.Center = new GeoCoordinate(geoposition.Coordinate.Latitude, geoposition.Coordinate.Longitude);
                Map.Center = new GeoCoordinate(53.911517, 27.454244);
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