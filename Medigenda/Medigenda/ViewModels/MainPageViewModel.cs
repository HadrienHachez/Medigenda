using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Medigenda
{
    class MainPageViewModel : PropertyChangeBase
    {
        private DateTime currentdate;
        public MainPageViewModel()
        {
            PreviousButton = new RelayCommand(PreviousButtonExecute);
            NextButton = new RelayCommand(NextButtonExecute);
            this.CurrentDate = DateTime.Now;
            this.DisplayMonth = this.CurrentDate.ToString("MMMM");

        }

        public DateTime CurrentDate
        {
            get
            {
   
                return this.currentdate;
            }
            set
            {
                this.currentdate = value;
                NotifyPropertyChanged();
            }
        }

        private string display;
        public string DisplayMonth
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
                NotifyPropertyChanged();

            }
        }



        public RelayCommand PreviousButton { get; set; }
        private void PreviousButtonExecute()
        {
            this.CurrentDate = this.CurrentDate.AddMonths(-1);
            this.DisplayMonth = this.CurrentDate.ToString("MMMM"); 
        }

        public RelayCommand NextButton { get; set; }
        private void NextButtonExecute()
        {
            this.CurrentDate = this.CurrentDate.AddMonths(+1);
            this.DisplayMonth = this.CurrentDate.ToString("MMMM");
        }


       
    }
}
