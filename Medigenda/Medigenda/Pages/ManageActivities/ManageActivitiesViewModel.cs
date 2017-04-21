using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Medigenda
{
    class ManageActivitiesViewModel : PropertyChangeBase
    {
        public ObservableCollection<Service> ActivitiesListing { get; set; } = new ObservableCollection<Service>();
        public RelayCommand AddButton { get; set; }
        public RelayCommand DeleteButton { get; set; }

        private Service selectedactivity;


        public ManageActivitiesViewModel()
        {
            AddButton = new RelayCommand(AddButtonExecute);
            DeleteButton = new RelayCommand(DeleteButtonExecute);
            this.ActivitiesListing = GetActivitiesListing();
        }


        #region Methods
        public ObservableCollection<Service> GetActivitiesListing()
        {
            //Remove and Update when DB is available
            return new ObservableCollection<Service>
            {
                 new Service(new ServiceName("CT")),
                 new Service(new ServiceName("Radio")),
                 new Service(new ServiceName("Mammo")),
            };

        }

        public void AddButtonExecute()
        {
            this.ActivitiesListing.Add(new Service(new ServiceName("New Service")));
        }

        public void DeleteButtonExecute()
        {
            //need a Validation
            this.ActivitiesListing.Remove(SelectedActivity);
        }

        #endregion

        #region Property
        public Service SelectedActivity
        {
            get { return selectedactivity; ; }
            set
            {
                selectedactivity = value;
                NotifyPropertyChanged();
            }
        }
        #endregion


    }
}
