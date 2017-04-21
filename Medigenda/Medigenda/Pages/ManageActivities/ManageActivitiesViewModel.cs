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
        private Shift selectedshift;

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

            Service CT = new Service(new ServiceName("CT"));
            CT.createShift(new DateTime(2017,5,5), "8:00", "9:00", 2, 3,CT.Service_name);
            ObservableCollection < Service > List = new ObservableCollection<Service>
            {
                 new Service(new ServiceName("Radio")),
                 new Service(new ServiceName("Mammo")),
            };
            List.Add(CT);
            
            return List;

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
            get { return selectedactivity;}
            set
            {
                selectedactivity = value;
                NotifyPropertyChanged();
            }
        }


        public Shift SelectedShift
        {
            get { return selectedshift;}
            set
            {
                selectedshift = value;
                NotifyPropertyChanged();
            }
        }
        #endregion


    }
}
