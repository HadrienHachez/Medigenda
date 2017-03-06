using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medigenda
{
    class Shift
    {   
        //Format de l'heure: HH:mm
        private string start_hour, end_hour;
        private List<Worker> workers;
        private int min_workers, opt_workers;

        public Shift(string start,string end, int min, int opt)
        {
            this.start_hour = start;
            this.end_hour = end;
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
