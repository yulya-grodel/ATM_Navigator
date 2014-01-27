using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ATM_Navigator.ViewModel;

namespace ATM_Navigator.Model
{
    [DataContract]
    public class Filter : BaseViewModel
    {
        public Filter(string name, string identifier, bool isChecked)
        {
            this.IsChecked = isChecked;
            this.Name = name;
            this.Identifier = identifier;
        }

        private string name;
        [DataMember]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private bool isChecked;
        [DataMember]
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        [DataMember]
        public string Identifier { get; set; }
    }
}
