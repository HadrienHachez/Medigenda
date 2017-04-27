using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using System.Collections.ObjectModel;

namespace Medigenda
{
    class MainPageViewModel : PropertyChangeBase
    {

        private ObservableCollection<Day> daylisting;
       

        private DateTime currentdate;
        public MainPageViewModel()
        {
            PreviousButton = new RelayCommand(PreviousButtonExecute);
            NextButton = new RelayCommand(NextButtonExecute);
            this.CurrentDate = DateTime.Now;
            
                      
     }

        #region Methods

        #endregion

        #region Property
        public DateTime CurrentDate
        {
            get
            {
   
                return this.currentdate;
            }
            set
            {
                this.currentdate = value;
                this.DayListing = new ObservableCollection<Day>();
                for (int i = 1; i <= DateTime.DaysInMonth(CurrentDate.Year, CurrentDate.Month); i++)
                {
                    this.DayListing.Add(new Day(new DateTime(this.CurrentDate.Year, this.CurrentDate.Month, i)));
                }
                NotifyPropertyChanged();
            }
        }


        
        public ObservableCollection<Day> DayListing
        {
            get
            {
                return this.daylisting;
            }
            set
            {
                this.daylisting = value;
                NotifyPropertyChanged();
            }
        }


        public ObservableCollection<WorkerInfoByDay> WorkerListing
        {
            get
            { return DayListing[0].InfoByDay; }
        }
        #endregion

        #region Property-Method Relays
        public RelayCommand PreviousButton { get; set; }
        private void PreviousButtonExecute()
        {
            this.CurrentDate = this.CurrentDate.AddMonths(-1);
        }

        public RelayCommand NextButton { get; set; }
        private void NextButtonExecute()
        {
            this.CurrentDate = this.CurrentDate.AddMonths(+1);
        }
        #endregion


    }
}
