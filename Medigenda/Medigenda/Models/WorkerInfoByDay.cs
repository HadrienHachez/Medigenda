using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace Medigenda
{
    public class WorkerInfoByDay : PropertyChangeBase
    {
        private Worker worker;
        private bool ispresent;
        private DateTime currentdate;
        public WorkerInfoByDay(Worker worker,DateTime date)
        {
            this.Worker = worker;
            this.IsPresent = true;
            this.currentdate = date;
            Vacation = new RelayCommand(VacationExecute);
            this.BackgroundButtonColor = GetColor;
        }

        #region Property
        public Worker Worker
        {
            get
            {
                return this.worker;
            }
            set
            {
                this.worker = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsPresent
        {
            get
            {
                return this.ispresent;
            }
            set
            {
                this.ispresent = value;
                NotifyPropertyChanged();
            }
        }


        #endregion

        #region Relay Property-Methods
        public RelayCommand Vacation { get; set; }
        private void VacationExecute()
        {
            this.IsPresent = this.IsPresent ? false : true;
            this.BackgroundButtonColor = GetColor;
            
        }
        #endregion

        #region GuiProperty
        private string backgroundbuttoncolor;
        public string GetColor
        {
            get
            {
                if (!this.IsPresent)
                {
                    return "Black";
                }
                else if ((this.currentdate.DayOfWeek == DayOfWeek.Saturday) || (this.currentdate.DayOfWeek == DayOfWeek.Sunday))
                {
                    return "Gray";
                }
                else
                    return "LightGray";
            }
        }


        public string BackgroundButtonColor
        {
            get
            {
                return this.backgroundbuttoncolor;
            }
            set
            {
                this.backgroundbuttoncolor = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

    }
}