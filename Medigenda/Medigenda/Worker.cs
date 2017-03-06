using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medigenda
{
    class Worker : Person
    {

        private List<ServiceName> skills;
        private Tima tima;
        private List<DateTime> non_working_days;
        private Dictionary<int, float> hours;

        public Worker(string first, string last) : base(string first, string last)
        {

        }
        
    }
}
