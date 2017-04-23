using System;
using System.Collections.Generic;
using System.Linq;
using AutoGenerateForm.Attributes;
using System.Text;
using System.Threading.Tasks;

namespace Medigenda
{
    public class Shift : PropertyChangeBase
    {
        private TimeSpan start_hour, end_hour;
        private List<Worker> workers;
        private int min_workers, opt_workers;
        private ServiceName service_name;
        private string display;

        //Format of the paramaters "start" and "end" corresponding to hours: HH:mm
        public Shift(string start,string end, int min, int opt, ServiceName serv_name)
        {

            //Both days are set to 0000/00/00 because only the hours are important here
            /*!!!!!Peut-être pas... travailler avec la date complète*/
            this.start_hour = ConvertStringToTimeSpan(start);
            this.end_hour = ConvertStringToTimeSpan(end);

            //this.date = date.ToOADate();

            this.min_workers = min;
            this.opt_workers = opt;

            this.service_name = serv_name;

            this.display = start + "-" + end; 
        }

        public TimeSpan ConvertStringToTimeSpan(string myinput)
        {
            string[] my_input_params = myinput.Split(':');
            return new TimeSpan(Int16.Parse(my_input_params[0]), Int16.Parse(my_input_params[1]), 0);
            
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
        public TimeSpan Start_hour
        {
            get { return this.start_hour; }
            set { this.start_hour = value; }
        }

        public TimeSpan End_hour
        {
            get { return this.end_hour; }
            set { this.end_hour = value; }
        }

        [AutoGenerateProperty]
        [IsNumeric]
        [Display("Minimal Needed Workers")]
        public int Min_workers
        {
            get { return this.min_workers; }
            set { this.min_workers = value; }
        }

       
        [AutoGenerateProperty]
        [IsNumeric]
        [Display("Optimal Workers")]
        public int Opt_workers
        {
            get { return this.opt_workers; }
            set { this.opt_workers = value; }
        }

        public string Display
        { 
            get { return this.display;}
        }
    }
}
