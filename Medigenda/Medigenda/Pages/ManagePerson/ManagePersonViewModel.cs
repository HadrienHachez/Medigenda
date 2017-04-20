
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
            Worker BW = new Worker("Wéry", "Benoit", 14161);
            Worker TS = new Worker("Selleslagh", "Tom", 14256);
            BW.addSkill(new ServiceName("IRM"));
            this.WorkerListing.Add(BW);
            this.WorkerListing.Add(TS);
            
        }

        public ObservableCollection<Worker> WorkerListing { get; set; } = new ObservableCollection<Worker>();
        

        
    }
}
