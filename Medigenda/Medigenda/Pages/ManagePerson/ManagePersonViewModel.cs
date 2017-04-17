
using AutoGenerateForm.Attributes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Linq;

namespace Medigenda
{
    public class ManagePersonViewModel : PropertyChangeBase
    {
        private Worker selectedStudent;
        [AutoGenerateProperty]
        public Worker SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                NotifyPropertyChanged();
            }
        }

        public ManagePersonViewModel()
        {
            //Get Info
            Worker BW = new Worker("Wéry", "Benoit", 14161);
            Worker TS = new Worker("Selleslagh", "Tom", 14256);
            this.WorkerListing.Add(BW);
            this.WorkerListing.Add(TS);
        }

        public ObservableCollection<Worker> WorkerListing { get; set; } = new ObservableCollection<Worker>();
    }
}
