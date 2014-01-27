using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ATM_Navigator.Model
{
    public class RelayCommand : ICommand
    {

        private readonly Action executeAction;

        private bool enabled = true;
        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                if (enabled != value)
                {
                    enabled = value;

                    if (CanExecuteChanged != null)
                        CanExecuteChanged(this, new EventArgs());
                }
            }
        }

        public RelayCommand(Action executeAction)
        {
            this.executeAction = executeAction;
        }

        public bool CanExecute(object parameter)
        {
            return enabled;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            executeAction();
        }
    }
}
