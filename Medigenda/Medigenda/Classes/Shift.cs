using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medigenda
{
    public class Shift
    {
        private double date;
        private DateTime start_hour, end_hour;
        private List<Worker> workers;
        private int min_workers, opt_workers;
        private ServiceName service_name;

        //Format of the paramaters "start" and "end" corresponding to hours: HH:mm
        public Shift(DateTime date, string start,string end, int min, int opt, ServiceName serv_name)
        {   
            string[] start_hour_params = start.Split(':');
            string[] end_hour_params = end.Split(':');

            //Both days are set to 0000/00/00 because only the hours are important here
            /*!!!!!Peut-être pas... travailler avec la date complète*/
            this.start_hour = new DateTime(date.Year, date.Month, date.Day, Int16.Parse(start_hour_params[0]), Int16.Parse(start_hour_params[1]), 0);
            this.end_hour = new DateTime(date.Year, date.Month, date.Day, Int16.Parse(end_hour_params[0]), Int16.Parse(end_hour_params[1]), 0);

            //this.date = date.ToOADate();

            this.min_workers = min;
            this.opt_workers = opt;

            this.service_name = serv_name;
        }

        /*Assigns a new worker "wo" to this shift
         * @pre - the size of the list "workers" has to be less than "opt_workers"
         *        the worker "wo" has to be free for that period of time
         * @post - the worker "wo" is added to the list "workers" and its schedule is updated
         *         with a new WorkingShift
         * */
        public void addWorker(Worker wo)
        {   
            if(this.workers.Count()<=this.opt_workers)
            {   
                //!! Conversion répétitive des DateTime hours en double -> quel format(s) stocker?
                /*if(wo.isFree(this.start_hour.ToOADate(), this.end_hour.ToOADate()))
                {
                    this.workers.Add(wo);
                    wo.updateSchedule(this.date, this.service_name, this.start_hour.ToOADate(), this.end_hour.ToOADate());
                }
                else
                {
                    //DISPLAY ERROR???
                }*/
            }
                
            else
            {
                //DISPLAY ERROR???
            }
            
        }

        public void delWorker(Worker wo)
        {

        }

        public void updateWorker(Worker wo)
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
            return shift_duration.Minutes;
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
