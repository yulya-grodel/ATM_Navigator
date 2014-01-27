using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_Navigator.ViewModel;
using Microsoft.Phone.Maps.Toolkit;

namespace ATM_Navigator.Model
{
    public class CustomPushpin : BaseViewModel
    {
        public Pushpin Pushpin;

        private string pushpinImageSource;
        public string PushpinImageSource
        {
            get { return pushpinImageSource; }
            set
            {
                pushpinImageSource = value;
                OnPropertyChanged("PushpinImageSource");
            }
        }
    }
}
