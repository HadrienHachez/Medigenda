using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medigenda
{
    class ServiceName
    {
        private string service_name;

        public ServiceName(string name)
        {
            this.service_name = name;
        }

        /******* Properties *******/
        public string Service_name
        {
            get { return this.service_name; }
        }
    }
}
