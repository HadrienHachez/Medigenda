using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medigenda
{
    class Day
    {
        private DateTime date;
        private List<Service> services;
        private Dictionary<String, Worker> present_workers;
        private List<Worker> available_workers;

        public Day(DateTime date)
        {
            this.date = date;
        }

        /******* Day *******/
        public bool isPresent(Worker work)
        {
            return false;
        }

        public void addService(Service serv)
        {

        }

        public void delService(Service serv)
        {

        }

        public WorkingDay getWorkingDay(Worker work)
        {
            return null;
        }

        /******* Tests *******/

        /******* Properties *******/

    }
}
