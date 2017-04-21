
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

        public RelayCommand CheckCommand { get; set; }
        async private void CheckCommandExecute()
        {
            MessageDialog testing = new MessageDialog("CheckCommand");
            await testing.ShowAsync();
        }
        private Worker selectedWorker;
        public Worker SelectedWorker
        {
            get {
                return selectedWorker; }
            set
            {

                selectedWorker = value;
                NotifyPropertyChanged();
            }
        }

        public Worker SelectedWorker2
        {
            get
            {
                return new Worker("Wéry", "Anélie", 14545); ;
            }
            set
            {
                NotifyPropertyChanged();
            }
        }



        public ManagePersonViewModel()
        {
            //Get Info
            CheckCommand= new RelayCommand(CheckCommandExecute);
            Worker BW = new Worker("Wéry", "Benoit", 14161);
            Worker TS = new Worker("Selleslagh", "Tom", 14256);
            this.WorkerListing.Add(BW);
            this.WorkerListing.Add(TS);
            
        }

        public ObservableCollection<Worker> WorkerListing { get; set; } = new ObservableCollection<Worker>();
        

        
    }
}
