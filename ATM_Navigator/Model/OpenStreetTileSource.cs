using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Navigator.Model
{
    public class CustomTileSource : Microsoft.Phone.Maps.Controls.TileSource
    {
        private Dictionary<string, string> mapTypesDictionary = new Dictionary<string, string>() { { "Open Streen Map", @"http://{0}.tile.openstreetmap.org/{1}/{2}/{3}.png" }, 
                                                                                                   { "Google Map", @"http://mt{0}.google.com/vt/lyrs=m&z={1}&x={2}&y={3}" } };

        //@"http://mt{0}.google.com/vt/lyrs={1}&z={2}&x={3}&y={4}"
        //@"http://khm{0}.google.com/kh/v=62&x={1}&y={2}&z={3}&s="

        public CustomTileSource(string uriFormatKey)
        {
            if (string.IsNullOrEmpty(uriFormatKey))
            {
                UriFormat = mapTypesDictionary["Open Streen Map"];
            }
            else
            {
                UriFormat = mapTypesDictionary[uriFormatKey];
            }
            _rand = new Random();
        }

        private readonly Random _rand;
        private readonly static string[] TilePathPrefixes = new[] { "a", "b", "c" };
        
        private string Server
        {
            get
            {
                return TilePathPrefixes[_rand.Next(3)];
            }
        }

        public override Uri GetUri(int x, int y, int zoomLevel)
        {
            if (zoomLevel > 0)
            {
                var url = string.Format(UriFormat, Server, zoomLevel, x, y);
                return new Uri(url);
            }
            return null;
        }     
    }   
}
