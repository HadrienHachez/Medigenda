using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medigenda
{
    public class Service
    {
        private ServiceName service_name;
        private List<Shift> shifts;

        public Service(ServiceName service_name)
        {
            this.service_name = service_name;
        }

        /******* Methods *******/

        /* Adds a new shift in the list "shifts" 
         * @pre - shift must exist
         * @post - the list "shifts" is updated and changes are saved in the database
         */
        public void addShift(Shift shift)
        {
            this.shifts.Add(shift);
        }

        /* Deletes the shift from the list "shifts" 
         * @pre - shift must exist
         * @post - the list "shifts" is updated and changes are saved in the database
         */
        public void delShift(Shift shift)
        {
            if(this.shifts.Contains(shift))
            {
                this.shifts.Remove(shift);
            }
        }

        public WorkingShift getWorkerShifts(Worker work)
        {
            return null;
        }

        //Returns the name of the service
        public string getName()
        {
            return this.service_name.Service_name;
        }

        /******* Tests *******/

        /******* Properties *******/
        public ServiceName Service_name
        {
            get { return this.service_name; }
        }
    }
}
