﻿using System;


namespace Medigenda
{
    public class OpenWeekDay : PropertyChangeBase
    {
        private DayOfWeek day;
        private bool isopen;

        public OpenWeekDay(DayOfWeek day)
        {
            CheckCommand = new RelayCommand(CheckCommandExecute);
            this.day = day;

            //by default, Closed for the Week-end
            switch (this.day)
            {
                case DayOfWeek.Saturday:
                    this.isopen = false;
                    break;
                case DayOfWeek.Sunday:
                    this.isopen = false;
                    break;
                default:
                    this.isopen = true;
                    break;
            }
              

        }


        #region Property
        public DayOfWeek Day
        {
            get { return this.day; }
        }

        public string DisplayDay
        {
            get { return this.day.ToString(); }
        }


        public bool IsOpen
        {
            get { return isopen; }
            set
            {
                isopen = value;
                NotifyPropertyChanged("IsOpen");
            }


        }

        #endregion

        #region Relay Property-Method
        public RelayCommand CheckCommand { get; set; }
        private void CheckCommandExecute()
        {
            this.isopen = this.isopen ? false : true;
        }
        #endregion
    }

}
