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
    //public class Person : PropertyChangeBase, IValidatable, INotifyDataErrorInfo
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

        [Display("Firstname")]
        [AutoGenerateProperty]
        public string First_name
        {
            get { return this.first_name; }
        }

        [Display("Lastname")]
        [AutoGenerateProperty]
        public string Last_name
        {
            get { return this.last_name; }
        }

        [Display("ID")]
        [AutoGenerateProperty]
        public int Id
        {
            get { return this.id; }
        }

        #endregion
    }
}
