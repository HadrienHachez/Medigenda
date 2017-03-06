using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medigenda
{
    class Service
    {
        private ServiceName service_name;
        private List<Shift> shifts;

        public Service(ServiceName service_name)
        {
            this.service_name = service_name;
        }

        /******* Methods *******/
        public void addShift(Shift shift)
        {

        }

        public void delShift(Shift shift)
        {

        }

        public WorkingShift getWorkerShifts(Worker work)
        {
            return null;
        }

        /******* Tests *******/

        /******* Properties *******/
        public ServiceName Service_name
        {
            get { return this.service_name; }
        }
    }
}
