using AutoGenerateForm.Attributes;
using MvvmValidation;
using System.Collections.ObjectModel;
using System;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using AutoGenerateForm.Helpers;



namespace Medigenda

{
    public class Person : PropertyChangeBase
    {
        private string first_name, last_name;
        private int id;


        public Person(string first, string last, int id)
        {
            this.first_name = first;
            this.last_name = last;
            this.id = id;
        }

        #region Methods

        public string dictKey()
        {
            return null;
        }
        #endregion


        #region Property
        [AutoGenerateProperty]
        [Display("Firstname")]
        [PropertyOrder(3)]
        public string First_name
        {
            get { return this.first_name; }
            set { this.first_name = value;
                   NotifyPropertyChanged(First_name); }
        }

        [AutoGenerateProperty]
        [Display("Lastname")]
        [PropertyOrder(2)]
        public string Last_name
        {
            get { return this.last_name; }
            set { this.last_name = value;
                NotifyPropertyChanged(Last_name);
            }
        }

        [AutoGenerateProperty]
        [Display("ID")]
        [PropertyOrder(1)]
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        #endregion
    }
}
