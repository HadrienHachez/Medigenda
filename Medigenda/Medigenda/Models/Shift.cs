using System;
using System.Collections.Generic;
using System.Linq;
using AutoGenerateForm.Attributes;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Medigenda
{
    public class Shift : PropertyChangeBase
    {
        private TimeSpan start_hour, end_hour;
        private ObservableCollection<Worker> workers;
        private int min_workers, opt_workers;
        private ServiceName service_name;
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

        


        //Format of the paramaters "start" and "end" corresponding to hours: HH:mm
        public Shift(string start,string end, int min, int opt, ServiceName serv_name)
        {
            //Both days are set to 0000/00/00 because only the hours are important here
            /*!!!!!Peut-être pas... travailler avec la date complète*/
            this.start_hour = ConvertStringToTimeSpan(start);
            this.end_hour = ConvertStringToTimeSpan(end);
            this.Workers = new ObservableCollection<Worker>();
            //this.date = date.ToOADate();
            this.min_workers = min;
            this.opt_workers = opt;
            this.service_name = serv_name;
        }


        #region Methods
        public TimeSpan ConvertStringToTimeSpan(string myinput)
        {
            string[] my_input_params = myinput.Split(':');
            return new TimeSpan(Int16.Parse(my_input_params[0]), Int16.Parse(my_input_params[1]), 0);
            
        }

       
        public int getSpan()
        {
            TimeSpan shift_duration = this.end_hour - this.start_hour;
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
