using System;
using AutoGenerateForm.Attributes;
using System.Collections.ObjectModel;

namespace Medigenda
{
    public class Shift : PropertyChangeBase
    {
        private TimeSpan start_hour, end_hour;
        private ObservableCollection<Worker> workers;
        private int min_workers, opt_workers;
        private ObservableCollection<OpenWeekDay> opening_day = new ObservableCollection<OpenWeekDay>
        {
            new OpenWeekDay(DayOfWeek.Monday),
            new OpenWeekDay(DayOfWeek.Tuesday),
            new OpenWeekDay(DayOfWeek.Wednesday),
            new OpenWeekDay(DayOfWeek.Thursday),
            new OpenWeekDay(DayOfWeek.Friday),
            new OpenWeekDay(DayOfWeek.Saturday),
            new OpenWeekDay(DayOfWeek.Sunday),
        };


        public Shift(TimeSpan start,TimeSpan end, int min, int opt)
        {
           
            this.Start_hour = start;
            this.End_hour = end;
            this.Workers = new ObservableCollection<Worker>();
            this.Min_workers = min;
            this.Opt_workers = opt;
        }


        #region Methods
        public TimeSpan ConvertStringToTimeSpan(string myinput)
        {
            string[] my_input_params = myinput.Split(':');
            return new TimeSpan(Int16.Parse(my_input_params[0]), Int16.Parse(my_input_params[1]), 0);
            
        }

       
        public int getSpan()
        {
            TimeSpan shift_duration = this.End_hour - this.Start_hour;
            return shift_duration.Minutes;
        }
        #endregion



        #region Property
        public ObservableCollection<Worker> Workers
        {
            get { return this.workers ; }
            set { this.workers = value; }
        }

        public ObservableCollection<OpenWeekDay> Opening_Day
        {
            get { return this.opening_day; }
            set { this.opening_day = value; }
        }


        public TimeSpan Start_hour
        {
            get { return this.start_hour; }
            set {
                  this.start_hour = value;
                  NotifyPropertyChanged();
            }
        }

        public TimeSpan End_hour
        {
            get { return this.end_hour; }
            set
            {
                this.end_hour = value;
                NotifyPropertyChanged();
            }
        }

        [AutoGenerateProperty]
        [IsNumeric]
        [Display("Minimal Needed Workers")]
        public int Min_workers
        {
            get { return this.min_workers; }
            set { this.min_workers = value; }
        }

       
        [AutoGenerateProperty]
        [IsNumeric]
        [Display("Optimal Workers")]
        public int Opt_workers
        {
            get { return this.opt_workers; }
            set { this.opt_workers = value; }
        }
        #endregion
    }
}
