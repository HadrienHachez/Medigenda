using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medigenda
{
    public class Worker : Person
    {

        private List<ServiceName> skills = new List<ServiceName>();
        private Tima tima;
        private List<DateTime> non_working_days = new List<DateTime>();
        private Dictionary<int, float> hours = new Dictionary<int, float>();
        private Dictionary<int, WorkingDay> schedule = new Dictionary<int, WorkingDay>();

        public Worker(string first, string last) : base(first, last)
        {

        }

        /******* Methods *******/

        /* Cheks if the employe is working on the day 'date'
         * @pre - 
         * @post - 
         */ 
        public bool isWorking(DateTime date)
        {
            bool is_working = false;

            //Cheks if this date is included in the list "non_workings_days" of the worker
            foreach (KeyValuePair<int, WorkingDay> entry in this.schedule)
            {
                int result = DateTime.Compare(date, entry.Value.Date);
                if (result == 0)
                {
                    is_working = true;
                }
            }

            return is_working;
        }


        /* Cheks if the employe can work on the day "date" or not
         * @pre - non_working_day must be uptodate
         * @post -
         */ 
        public bool canWork(DateTime date)
        {
            bool can_work = true;

            //Cheks if this date is included in the list "non_workings_days" of the worker
            foreach (DateTime d_t in this.non_working_days)
            {
                int result = DateTime.Compare(date, d_t);
                if (result == 0)
                {
                    can_work = false;
                }
            }

            return can_work;
        }


        public float getHours(DateTime date)
        {
            return -1;
        }

        /* Adds a day of break 
         * @pre - 
         * @post - the list "non_working_days" is updated and so is the database
         */ 
        public void addBreak(DateTime date)
        {
            this.non_working_days.Add(date);
        }

        /* Deletes the day from the list "non_working_days"
        * @pre - the day corresponding to "date" must be included in the list "non_working_days"
        * @post - the list "non_working_days" is updated and so is the database
        */
        public void delBreak(DateTime date)
        {
            if(this.non_working_days.Contains(date))
            {
                this.non_working_days.Remove(date);
            }
        }

        /* Add a new service to the list "skills" of the worker
         * @pre - service_name must exist
         * @post - the list "skills" is updated and changes are saved in the database
         */
        public void addSkill(ServiceName service_name)
        {
            this.skills.Add(service_name);
        }

        /* Delete the service from the list "skills" of the worker
         * @pre - service_name must exist
         * @post - the list "skills" is updated and changes are saved in the database
         */
        public void delSkill(ServiceName service_name)
        {
            if(this.skills.Contains(service_name))
            {
                this.skills.Remove(service_name);
            }
            
        }



        /******* Properties *******/

        public Tima Tima
        {
            get { return this.tima; }
            set { this.tima = value; }
        }

        public List<ServiceName> Skills
        {
            get { return this.skills;  }
        }

        public List<DateTime> Non_working_days
        {
            get { return this.non_working_days; }
        }
    }
}
