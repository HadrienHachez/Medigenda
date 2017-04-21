using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGenerateForm.Attributes;

namespace Medigenda
{
    public class ServiceName
    {
        private string service_name;

        public ServiceName(string name)
        {
            this.service_name = name;
        }

        /******* Properties *******/
        [Display("Testing")]
        [AutoGenerateProperty]
        public string Service_name
        {
            get { return this.service_name; }
        }
    }
}
