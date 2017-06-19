using System;
using AutoGenerateForm.Attributes;

namespace Medigenda
{
    public class WorkerSchedule : PropertyChangeBase
    {
        private TimeSpan start_hour;
        private TimeSpan end_hour;
        private string output;
        private string color;
        private int id;
        

        public WorkerSchedule(TimeSpan start,TimeSpan end,string abreviation,string outputcolor,int id)
        {
            this.Start_hour = start;
            this.End_hour = end;
            this.Output = abreviation;
            this.Color = outputcolor;
            this.Id = id;
        }


        public int Id
        {
            get
            {
                return this.id;

            }
            set
            {
                this.id = value;
                NotifyPropertyChanged();
            }
        }

        #region Property
        //[AutoGenerateProperty]
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


        //[AutoGenerateProperty]
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
        [AutoGenerateProperty]
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

        [AutoGenerateProperty]
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
