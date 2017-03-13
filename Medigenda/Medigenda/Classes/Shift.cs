using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medigenda
{
    public class Shift
    {   
        
        private DateTime start_hour, end_hour;
        private List<Worker> workers;
        private int min_workers, opt_workers;

        //Format of the paramaters "start" and "end" corresponding to hours: HH:mm
        public Shift(string start,string end, int min, int opt)
        {
            string[] start_hour_params = start.Split(':');
            string[] end_hour_params = end.Split(':');

            //Both days are set to 0000/00/00 because only the hours are important here
            /*!!!!!Peut-être pas... travailler avec la date complète*/
            this.start_hour = new DateTime(0, 0, 0, Int16.Parse(start_hour_params[0]), Int16.Parse(start_hour_params[1]), 0);
            this.end_hour = new DateTime(0, 0, 0, Int16.Parse(end_hour_params[0]), Int16.Parse(end_hour_params[1]), 0);

            this.min_workers = min;
            this.opt_workers = opt;
        }

        public void addWorker(Worker work)
        {

        }

        public void delWorker(Worker work)
        {

        }

        public void updateWorker(Worker work)
        {

        }

        public void getShiftDetails()
        {

        }

        /* Returns the duration of the shift in minutes
         * @pre -
         * @post -
         */ 
        public int getSpan()
        {
            TimeSpan shift_duration = this.end_hour - this.start_hour;
            return shift_duration.Hours;
        }

        /******* Tests *******/


        /******* Properties ********/
        public DateTime Start_hour
        {
            get { return this.start_hour; }
            set { this.start_hour = value; }
        }

        public DateTime End_hour
        {
            get { return this.end_hour; }
            set { this.end_hour = value; }
        }

        public int Min_workers
        {
            get { return this.min_workers; }
            set { this.min_workers = value; }
        }

        public int Opt_workers
        {
            get { return this.opt_workers; }
            set { this.opt_workers = value; }
        }
    }
}
