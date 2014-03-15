using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ATM_Navigator.Model;

namespace ATM_Navigator.Helper
{
    public class AllATMsTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AllAtms { get; set; }
        public DataTemplate DefaultTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var atmItem = item as ATM;
            if (atmItem != null)
            {
                if (atmItem.Name == "Все банки")
                {
                    return AllAtms;
                }               
            }
            return DefaultTemplate;
        }
    }
}
