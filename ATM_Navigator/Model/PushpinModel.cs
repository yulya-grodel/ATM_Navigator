using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Navigator.Model
{
    public class PushpinModel
    {
        public string ImageUrl { get; set; }
        public GeoCoordinate Location { get; set; }
    }
}
