using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace Medigenda
{
    public class Day : PropertyChangeBase
    {
        private DateTime date_time;
        private ObservableCollection<WorkerInfoByDay> infobyday;
        private List<Service> services = new List<Service>();
        private List<Worker> available_workers = new List<Worker>();


        //The format of the date must be YY:MM:DD -> example: "2017:03:12"
        public Day(DateTime date)
        {
            this.date_time = date;
            this.InfoByDay = GetWorkerListing();
            OpenContentDialogBox = new RelayCommand(OpenContentDialogBoxExecute);
        }

       


        /* Adds a new service in the list "services" 
         * @pre - serv must exist
         * @post - the list "services" is updated and changes are saved in the database
         */
        public void addService(Service serv)
        {
            this.services.Add(serv);
        }

        /* Deletes the service from the list "services" 
         * @pre - serv must exist
         * @post - the list "services" is updated and changes are saved in the database
         */
        public void delService(Service serv)
        {
            if(this.services.Contains(serv))
            {
                this.services.Remove(serv);
            }
        }

        public WorkingDay getWorkingDay(Worker work)
        {
            return null;
        }




        //Displays information about the day !!!!!! N'est valable que en mode développement console -> aide pour progra


        public ObservableCollection<WorkerInfoByDay> GetWorkerListing()
        {
            //Remove and Update when DB is available
            return new ObservableCollection<WorkerInfoByDay>
            {
                 new WorkerInfoByDay(new Worker("Benoit", "Wéry", 14256),this.Date_time),
                 new WorkerInfoByDay(new Worker("Tom", "Sellelsagh", 14161),this.Date_time),
                 new WorkerInfoByDay(new Worker("Marcin", "Krasowsky", 42),this.Date_time),
                 new WorkerInfoByDay(new Worker("Hadrien", "Hachez", 44),this.Date_time)

            };

        }


        /******* Tests *******/

        /******* Properties *******/

        public ObservableCollection<WorkerInfoByDay> InfoByDay
        {
            get
            {
                return this.infobyday;
            }
            set
            {
                this.infobyday = value;
                NotifyPropertyChanged();
            }
        }

        private FillTheService contentdialogbox = new FillTheService();

        public FillTheService ContenDialogBox
        {
            get { return contentdialogbox; }
            set { this.contentdialogbox = value; }
        }

        public RelayCommand OpenContentDialogBox { get; set; }
        private async void OpenContentDialogBoxExecute()
        {
            ContenDialogBox = new FillTheService();
            foreach (WorkerInfoByDay Info in InfoByDay)
            {
               if (Info.IsPresent)
                {
                    ContenDialogBox.Available.Add(Info.Worker);
                }
            }
            await ContenDialogBox.ShowAsync();
        }

        public DateTime Date_time
        {
            get { return this.date_time; }
        }

        public List<Service> Services
        {
            get { return this.services; }
        }

        
        #region GuiProperty


        #endregion

    }
}
