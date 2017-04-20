using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGenerateForm.Attributes;
using AutoGenerateForm.Uwp;
using Windows.UI.Xaml;
using Windows.UI.Popups;

namespace Medigenda
{ 
    public class HaveSkills : PropertyChangeBase
    {
        private ServiceName service;
        private bool havethisskills;
        
        public HaveSkills(ServiceName service)
        {
            CheckCommand = new RelayCommand(CheckCommandExecute);
            this.service = service;
            this.havethisskills = false;
        }

        public ServiceName Service
        {
            get { return this.service; }
        }

        public RelayCommand CheckCommand { get; set; }
        private void CheckCommandExecute()
        {
            this.havethisskills = this.havethisskills ? false : true;
        }


        public bool HaveThisSkills
        {
            get { return havethisskills; }
            set {
                havethisskills = value;
                NotifyPropertyChanged("HaveThisSkills");
                }
                

        }

        
    }
}
