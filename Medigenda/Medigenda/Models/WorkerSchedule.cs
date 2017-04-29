using System;

namespace Medigenda
{
    public class WorkerSchedule : PropertyChangeBase
    {
        private TimeSpan start_hour;
        private TimeSpan end_hour;
        private TimeSpan hourworked;
        private string output;
        private string color;
        

        public WorkerSchedule(TimeSpan start,TimeSpan end,string abreviation,string outputcolor)
        {
            this.Start_hour = start;
            this.End_hour = end;
            this.Output = abreviation;
            this.Color = outputcolor;
        }

        #region Property
        public TimeSpan Start_hour
        {   get
            {
                return this.start_hour;

            }
            set
            {
                this.start_hour = value;
                NotifyPropertyChanged();
            }
        }

        public TimeSpan End_hour
        {
            get
            {
                return this.end_hour;

            }
            set
            {
                this.end_hour = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region GuiProperty
        public string Output
        {
            get
            {
                return this.output;

            }
            set
            {
                this.output = value;
                NotifyPropertyChanged();
            }
        }

        public string Color
        {
            get
            {
                return this.color;

            }
            set
            {
                this.color = value;
                NotifyPropertyChanged();
            }
        }
        #endregion
    }
}
