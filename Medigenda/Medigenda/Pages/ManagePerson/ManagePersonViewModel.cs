
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
        private Worker selectedWorker;

       
        public ManagePersonViewModel()
        {
            this.WorkerListing = GetWorkerListing();
        }


        #region Methods
        public ObservableCollection<Worker> GetWorkerListing()
        {
            return new ObservableCollection<Worker>
            {
                 new Worker("Wéry", "Benoit", 14256),
                 new Worker("Selleslagh", "Tom", 14161)
            };

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
