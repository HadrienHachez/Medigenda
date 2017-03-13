using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medigenda
{
    public class WorkingDay
    {
        private DateTime date;
        private List<WorkingShift> shifts;
        private float working_hours;

        public WorkingDay(DateTime date)
        {
            this.date = date;
        }

        /******* Methods *******/
        public void addShift(Shift shift)
        {

        }

        public void delShift(Shift shift)
        {
            
        }

        public int dictKey()
        {
            return -1;
        }

        public List<WorkingShift> getShiftDetails()
        {
            return null;
        }


        /******* Properties *******/
        public float Working_hours
        {
            get { return this.working_hours; }
        }

        public DateTime Date
        {
            get { return this.date; }
        }

   
    }
}
