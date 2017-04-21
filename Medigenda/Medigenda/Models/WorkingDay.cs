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
        private double start_hour, end_hour;
        private List<WorkingShift> working_shifts;
        //!!! take accounts of the breaks during the day. The total is expressed in minutes
        private double total_working_hours;

        public WorkingDay(DateTime date)
        {
            this.date = date;
        }

        /******* Methods *******/

        /*Creates a new workingShift for that WorkingDay and adds it to the list "working_shifts
         * @pre - 
         * @post -
         */ 
        public void addWorkingShift(ServiceName serv_name, double start_h, double end_h)
        {
            WorkingShift work_shift = new WorkingShift(serv_name, start_h, end_h);
            this.working_shifts.Add(work_shift);
            this.updateHours();
            this.updateTotalWorkingHours();
        }

        public void delWorkingShift(WorkingShift work_shift)
        {
            if(this.working_shifts.Contains(work_shift))
            {
                this.working_shifts.Remove(work_shift);
                this.updateHours(); 
                this.updateTotalWorkingHours();
            }
        }

        /*Returns its own Key for dictionaries. The key corresponds to the date converted into a double
         * @pre -
         * @post -
         */ 
        public double dictKey()
        {
            //return this.date.ToOADate();
            return 0;
        }

        public List<WorkingShift> getShiftDetails()
        {
            return null;
        }

        /*Updates the start_hour and the end_hour. It has to chek each working_shift in the list
         * @pre - start_hour and end_hour are hours THE SAME DAY expressed in double type
         * @post - start_hour and/or end_hour will be changed if the given ones are earlier/later
         */
         public void updateHours()
        {
            double start_h = this.start_hour;
            double end_h = this.end_hour;
            foreach (WorkingShift work_shift in working_shifts)
            {
                //If the hour "start" is EARLIER than the current "start_hour" then the difference will be positive
                if (start_h - work_shift.Start_hour > 0)
                {
                    start_h = work_shift.Start_hour;
                }

                //If the hour "end" is LATER than the current "end_hour" then the difference will be negative
                if (end_h - work_shift.End_hour < 0)
                {
                    end_h = work_shift.End_hour;
                }
            }

            this.start_hour = start_h;
            this.end_hour = end_h;
        } 

        /*Updates the total hours for that day
         * @pre -
         * @post - 
         */
         public void updateTotalWorkingHours()
        {
            double total = 0;
            foreach(WorkingShift work_shift in this.working_shifts)
            {
                total += work_shift.getSpan();
            }

            this.total_working_hours = total;
        } 

        /******* Properties *******/
        public double Total_orking_hours
        {
            get { return this.total_working_hours; }
        }

        public DateTime Date
        {
            get { return this.date; }
        }

   
    }
}
