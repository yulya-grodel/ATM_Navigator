using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Navigator.Model
{
    public class OpenStreetTileSource : Microsoft.Phone.Maps.Controls.TileSource
    {
        public OpenStreetTileSource()
        {
            UriFormat = @"http://{0}.tile.openstreetmap.org/{1}/{2}/{3}.png";
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
