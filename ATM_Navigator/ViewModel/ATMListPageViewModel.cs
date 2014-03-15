using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ATM_Navigator.Model;

namespace ATM_Navigator.ViewModel
{
    [DataContract]
    public class ATMListPageViewModel
    {
        public List<ATM> ATMList
        {
            get
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains("ATMList"))
                {
                    return (List<ATM>)IsolatedStorageSettings.ApplicationSettings["ATMList"];
                }
                else
                {
                    var list = PopulateATMList();
                    IsolatedStorageSettings.ApplicationSettings.Add("ATMList", list);
                    IsolatedStorageSettings.ApplicationSettings.Save();
                    return list;
                }
            }
        }
              
        private List<ATM> PopulateATMList()
        {
            var list = new List<ATM>
            {
                new ATM("", "Все банки", "spec:all", false),
                new ATM("../Assets/Icons/alfa.png", "Альфа-Банк", "alfa", false),
                new ATM("../Assets/Icons/belagroprom.png", "Белагропромбанк", "belagroprom", false),
                new ATM("../Assets/Icons/belarus.png", "Беларусбанк", "belarus", false),
                new ATM("../Assets/Icons/bve.png", "Белвнешэкономбанк", "bve", false),
                new ATM("../Assets/Icons/belgazprom.png", "Белгазпромбанк", "belgazprom", false),
                new ATM("../Assets/Icons/belinvest.png", "Белинвестбанк", "belinvest", false),
                new ATM("../Assets/Icons/bbmb.png", "Белорусский Банк Малого Бизнеса", "bbmb", false),
                new ATM("../Assets/Icons/bnb.png", "Белорусский Народный Банк", "bnb", false),
                new ATM("../Assets/Icons/belros.png", "Белросбанк", "belros", false),
                new ATM("../Assets/Icons/belswiss.png", "БелСвиссБанк", "belswiss", false),
                new ATM("../Assets/Icons/bps.png", "БПС-Сбербанк", "bps", false),
                new ATM("../Assets/Icons/bta.png", "БТА Банк", "bta", false),
                new ATM("../Assets/Icons/vtb.png", "ВТБ Банк", "vtb", false),
                new ATM("../Assets/Icons/delta.png", "Дельта Банк", "delta", false),
                new ATM("../Assets/Icons/euro.png", "Евробанк", "euro", false),
                new ATM("../Assets/Icons/credex.png", "Кредэксбанк", "credex", false),
                new ATM("../Assets/Icons/mm.png", "Москва-Минск Банк", "mm", false),
                new ATM("../Assets/Icons/mtb.png", "МТБанк", "mtb", false),
                new ATM("../Assets/Icons/paritet.png", "Паритетбанк", "paritet", false),
                new ATM("../Assets/Icons/prior.png", "Приорбанк", "prior", false),
                new ATM("../Assets/Icons/rrb.png", "РРБ-Банк", "rrb", false),
                new ATM("../Assets/Icons/sbb.png", "Сомбелбанк", "sbb", false),
                new ATM("../Assets/Icons/techno.png", "Технобанк", "techno", false),
                new ATM("../Assets/Icons/trust.png", "Трастбанк", "trust", false),
                new ATM("../Assets/Icons/fransa.png", "Франсабанк", "fransa", false),
                new ATM("../Assets/Icons/homecredit.png", "Хоум Кредит Банк", "homecredit", false),
                new ATM("../Assets/Icons/zepter.png", "Цептер Банк", "zepter", false)
            };
            return list;
        }      
    }
}
