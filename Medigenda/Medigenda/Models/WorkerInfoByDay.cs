using System;

namespace Medigenda
{
    public class WorkerInfoByDay : PropertyChangeBase
    {
        private Worker worker;
        private bool ispresent;
        private DateTime currentdate;
        private WorkerSchedule workedtoday;
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

        public WorkerSchedule WorkedToday
        {
            get
            {
                return this.workedtoday;
            }
            set
            {
                this.workedtoday = value;
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
            this.ContentButton = Content; 
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
                    return "#222266";
                }
                else if (this.WorkedToday != null)
                {
                    return this.WorkedToday.Color;
                }
                else if ((this.currentdate.DayOfWeek == DayOfWeek.Saturday) || (this.currentdate.DayOfWeek == DayOfWeek.Sunday))
                {
                    return "Gray";
                }
               
                else
                    return "LightGray";
            }
        }


        private string content;
        public string Content
        {
            get
            {
                if (!this.IsPresent)
                {
                    return "V";
                }
                else if (this.WorkedToday != null)
                {
                    return this.WorkedToday.Output;
                }
                else
                    return "";
            }
        }



        public string ContentButton
        {
            get
            {
                return this.content;
            }
            set
            {
                this.content = value;
                NotifyPropertyChanged();
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