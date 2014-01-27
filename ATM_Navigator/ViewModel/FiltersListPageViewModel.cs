using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ATM_Navigator.Model;

namespace ATM_Navigator.ViewModel
{
    public class FiltersListPageViewModel
    {
        public List<Filter> FiltersList
        {
            get
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains("FiltersList"))
                {
                    return (List<Filter>)IsolatedStorageSettings.ApplicationSettings["FiltersList"];
                }
                else
                {
                    var filtersList = PopulateFiltersList();
                    IsolatedStorageSettings.ApplicationSettings.Add("FiltersList", filtersList);
                    IsolatedStorageSettings.ApplicationSettings.Save();
                    return filtersList;
                }
            }
        }

        private List<Filter> PopulateFiltersList()
        {
            var list = new List<Filter>();
            list.Add(new Filter("Банк", "type:bank", false));
            list.Add(new Filter("Обмен валют", "type:exchange", false));
            list.Add(new Filter("Терминал", "type:terminal", false));
            list.Add(new Filter("Банкомат (BYR)", "type:atm:currency:byr", false));
            list.Add(new Filter("Банкомат (RUR)", "type:atm:currency:rur", false));
            list.Add(new Filter("Банкомат (USD)", "type:atm:currency:usd", false));
            list.Add(new Filter("Банкомат (EUR)", "type:atm:currency:eur", false));
            return list;
        }
    }
}
