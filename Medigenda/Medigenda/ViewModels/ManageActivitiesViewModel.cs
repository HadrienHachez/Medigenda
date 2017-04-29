using System;
using System.Collections.ObjectModel;

namespace Medigenda
{
    class ManageActivitiesViewModel : PropertyChangeBase
    {
       
        private ObservableCollection<Service> activitieslisting;
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
            Service CT = new Service("CT");
            CT.ShiftListing.Add(new Shift(new TimeSpan(8, 0, 0), new TimeSpan(17, 0, 0), 2, 3));
            CT.ShiftListing.Add(new Shift(new TimeSpan(16, 0, 0), new TimeSpan(22, 0, 0), 2, 3));

            ObservableCollection<Service> List = new ObservableCollection<Service>
            {
                 new Service("Radio"),
                 new Service("Mammo")
            };
            List.Add(CT);
            return List;

        }

        public void AddButtonExecute()
        {
            this.ActivitiesListing.Add(new Service("New Service"));
        }

        public void DeleteButtonExecute()
        {
            //need a Validation
            this.ActivitiesListing.Remove(SelectedActivity);
        }

        #endregion

        #region Property
        public ObservableCollection<Service> ActivitiesListing
        {
            get { return this.activitieslisting; }
            set
            {
                this.activitieslisting = value;
                NotifyPropertyChanged();
            }
        }


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
