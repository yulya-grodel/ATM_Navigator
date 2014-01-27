using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Navigator.Model
{
    public class RootObject
    {
        public string addr { get; set; }
        public string prov { get; set; }
        public string phone { get; set; }
        public string place { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string type { get; set; }
        // public string time { get; set; }
    }
}
