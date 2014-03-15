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
    public class ATM : BaseViewModel
    {
        public ATM(string pictureUrl, string name, string identifier, bool isChecked)
        {
            //this.PictureUrl = pictureUrl;
            this.Name = name;
            this.Identifier = identifier;
            this.IsChecked = isChecked;
        }

        //private string pictureUrl;
        //[DataMember]
        //public string PictureUrl
        //{
        //    get { return pictureUrl; }
        //    set
        //    {
        //        pictureUrl = value;
        //        OnPropertyChanged("PictureUrl");
        //    }
        //}

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
