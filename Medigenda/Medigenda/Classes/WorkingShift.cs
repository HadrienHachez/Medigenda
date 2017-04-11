using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medigenda
{
    public class WorkingShift
    {
        //Format de l'heure: HH:mm
        private double start_hour, end_hour;
        //private TimeSpan time_span;
        private ServiceName service_name;

        public WorkingShift(ServiceName serv_name, double start, double end)
        {
            this.service_name = serv_name;
            this.start_hour = start;
            this.end_hour = end;
        }

        /******* Methods *******/

        /*Returns the duration of the Workingshift 
         * @pre -
         * @post - the duration is expressed in MINUTES
         */ 
        public double getSpan()
        {
            //TimeSpan time_span = DateTime.FromOADate(end_hour) - DateTime.FromOADate(start_hour);
            //return time_span.TotalMinutes;
            return 0;
        }

        /******* Properties ********/

        public double Start_hour
        {
            get { return this.start_hour; }
        }

        public double End_hour
        {
            get { return this.end_hour; }
        }


    }
}
