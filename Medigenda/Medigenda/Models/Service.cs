using System.Collections.ObjectModel;
using AutoGenerateForm.Attributes;

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

        #region Property
        public ObservableCollection<Shift> ShiftListing
        {
            get {
                return shifts;
                }
            set
            {
                shifts = value;
                NotifyPropertyChanged();
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
        #endregion
    }
}
