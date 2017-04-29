using System;
using System.Collections.Generic;
using AutoGenerateForm.Attributes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Medigenda
{ 
    public class Service : PropertyChangeBase
    {
        private string service_name;
        private ObservableCollection<Shift> shifts = new ObservableCollection<Shift>();

        public Service(string service_name)
        {
            this.Service_name = service_name;
        }


        public ObservableCollection<Shift> ShiftListing
        {
            get {
                return this.shifts;
                }
        }

        public string Service_name
        {
            get { return this.service_name; }
            set
            {
                this.service_name = value;
                NotifyPropertyChanged();
            }
        }
    }
}
