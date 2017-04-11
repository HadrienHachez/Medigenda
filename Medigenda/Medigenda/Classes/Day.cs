using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medigenda
{
    public class Day
    {
        private DateTime date_time;
        private double date_double;
        private List<Service> services = new List<Service>();
        private Dictionary<String, Worker> present_workers = new Dictionary<string, Worker>();
        private List<Worker> available_workers = new List<Worker>();

        //The format of the date must be YY:MM:DD -> example: "2017:03:12"
        public Day(DateTime date)
        {
            this.date_time = date;
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

        public double convertDateToDouble()
        {   
            if (this.date_double == default(double))
            {
                //this.date_double  =  this.date_time.ToOADate();
            }

            return this.date_double;
        }


        //Displays information about the day !!!!!! N'est valable que en mode développement console -> aide pour progra
        public void displayInfo()
        {
           /* Console.WriteLine("Date: " + this.date_time.ToString("D"));
            Console.WriteLine("Services: ");
            foreach(Service serv in services)
            {
                Console.WriteLine("\t- " + serv.getName());
            }

            Console.WriteLine("Present workers: ");
            foreach(Worker wo in available_workers)
            {
                Console.WriteLine("\t- " + wo.First_name + " " + wo.Last_name);
            }*/
        }

        /******* Tests *******/

        /******* Properties *******/
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
