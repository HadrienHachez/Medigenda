using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medigenda
{
    public class Company
    {
        private string name;
        //!! current_id must be saved in the database of the company
        public static int current_id;
        private List<Worker> workers;
        private Dictionary<int, Day> days;
        private List<Service> services = new List<Service>();

        //The lists "workers" and "days" are created with the database in the class GENERATOR
        public Company(string name, List<Worker> workers, Dictionary<int, Day> days)
        {
            this.name = name;
            this.workers = workers;
            this.days = days;
        }
       
        /******* Methods *******/

        /* Creates a new worker and associates it an id 
         * @pre - 
         * @post - the worker is added to the list "workers" and the database is updated. The current_id has been incremented
         */
        public void createWorker(string first, string last)
        {
            current_id += 1;
            Worker new_worker = new Worker(first, last, current_id);
            this.workers.Add(new_worker);
            //UPDATE DB//
        }

        /* Deletes the worker "wo"
         * @pre - "wo" must be included in the list "workers"
         * @post - the list and the database are updated
         */
        public void delWorker(Worker wo)
        {
            if(this.workers.Contains(wo))
            {
                this.workers.Remove(wo);
                //UPDATE DB//
            }
        }

        /* Creates a new service
         * @pre - 
         * @post - the service is added to the list "services" and the database is updated. 
         */
         public void createService(string serv_name)
        {
            Service new_serv = new Service(serv_name);
            this.services.Add(new_serv);
            //UPDTADE DB//
        }

        /* Deletes the service "serv" from the list "services"
         * @pre - "serv" must be included in the list "services"
         * @post - the list and the database are updated
         */
        public void delService(Service serv)
        {
            if(this.services.Contains(serv))
            {
                this.services.Remove(serv);
            }
        }

        public void addDay(Day day)
        {

        }

        public void updateWorkerSchedule()
        {

        }
         
        public List<Worker> presentWorkers(DateTime date)
        {
            return null;
        }

        /******* Properties *******/
        public List<Worker> Workers
        {
            get { return this.workers; }
        }

        public List<Service> Services
        {
            get { return this.services; }
        }

    }
}
