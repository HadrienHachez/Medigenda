namespace Medigenda
{ 
    public class HaveSkills : PropertyChangeBase
    {
        private Service service;
        private bool havethisskills;
        
        public HaveSkills(Service service)
        {
            CheckCommand = new RelayCommand(CheckCommandExecute);
            this.Service = service;
            this.havethisskills = false;
        }



        #region Property

        public Service Service
        {
            get { return this.service; }
            set {
                this.service = value;
                NotifyPropertyChanged();
                }
        }


        public bool HaveThisSkills
        {
            get { return havethisskills; }
            set {
                havethisskills = value;
                NotifyPropertyChanged();
                }
                

        }
        #endregion

        #region Relay Property-Method
        public RelayCommand CheckCommand { get; set; }
        private void CheckCommandExecute()
        {
            this.havethisskills = this.havethisskills ? false : true;
        }
        #endregion


    }
}
