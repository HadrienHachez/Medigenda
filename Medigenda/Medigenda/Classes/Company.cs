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
        private List<Worker> workers;
        private Dictionary<int, Day> days;
        private List<ServiceName> services;

        public Company(string name, List<Worker> workers, Dictionary<int, Day> days)
        {
            this.name = name;
            this.workers = workers;
            this.days = days;
        }
       
        /******* Methods *******/
        public void addWorker(Worker wo)
        {

        }

        public void delWorker(Worker wo)
        {

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


    }
}
