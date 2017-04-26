using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Medigenda
{
    public class Day : PropertyChangeBase
    {
        private DateTime date_time;
        private ObservableCollection<Worker> workerlisting;
        private List<Service> services = new List<Service>();
        private Dictionary<String, Worker> present_workers = new Dictionary<string, Worker>();
        private List<Worker> available_workers = new List<Worker>();


        //The format of the date must be YY:MM:DD -> example: "2017:03:12"
        public Day(DateTime date)
        {
            this.date_time = date;
            this.WorkerListing = GetWorkerListing();
        }

       

        /******* Methods *******/

        /* Checks if the worker "wo" is present for working that day
         * @pre - wo must exist
         * @post - 
         */

        public bool isPresent(Worker wo)
        {
            bool is_present = true;

            //Cheks if this current day is included in the list "non_workings_days" of the worker
            foreach(DateTime d_t in wo.Non_working_days)
            {   
                int result = DateTime.Compare(this.date_time, d_t);
                if(result == 0)
                {
                    is_present = false;
                }
            }

            return is_present;
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


        public ObservableCollection<Worker> GetWorkerListing()
        {
            //Remove and Update when DB is available
            return new ObservableCollection<Worker>
            {
                 new Worker("Benoit", "Wéry", 14256),
                 new Worker("Tom", "Sellelsagh", 14161)
            };

        }

        /******* Tests *******/

        /******* Properties *******/

        public ObservableCollection<Worker> WorkerListing
        {
            get
            {
                return this.workerlisting;
            }
            set
            {
                this.workerlisting = value;
                NotifyPropertyChanged();
            }
        }


        public DateTime Date_time
        {
            get { return this.date_time; }
        }

        public List<Service> Services
        {
            get { return this.services; }
        }

        


    }
}
