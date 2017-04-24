
using AutoGenerateForm.Attributes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.DataTransfer;
using System;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using Windows.UI.Xaml;


namespace Medigenda
{
    public class ManagePersonViewModel : PropertyChangeBase
    {

        public ObservableCollection<Worker> WorkerListing { get; set; } = new ObservableCollection<Worker>();
        public RelayCommand AddButton { get; set; }
        public RelayCommand DeleteButton { get; set; }

        private Worker selectedWorker;

       
        public ManagePersonViewModel()
        {
            AddButton = new RelayCommand(AddButtonExecute);
            DeleteButton = new RelayCommand(DeleteButtonExecute);
            this.WorkerListing = GetWorkerListing();
        }


        #region Methods
        public ObservableCollection<Worker> GetWorkerListing()
        {
            //Remove and Update when DB is available
            return new ObservableCollection<Worker>
            {
                 new Worker("Wéry", "Benoit", 14256),
                 new Worker("Selleslagh", "Tom", 14161)
            };

        }

        public void AddButtonExecute()
        {
            this.WorkerListing.Add(new Worker("Firstname", "Lastname", 0));
        }

        public void DeleteButtonExecute()
        {
            //need a Validation
            this.WorkerListing.Remove(SelectedWorker);
        }

        #endregion

        #region Property
        public Worker SelectedWorker
        {
            get {   return selectedWorker;}
            set {
                    selectedWorker = value;
                    NotifyPropertyChanged();}
        }
        #endregion


    }
}
