using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medigenda
{
    public class Person
    {
        private string first_name, last_name;
        private int id;

        public Person(string first, string last, int id)
        {
            this.first_name = first;
            this.last_name = last;
            this.id = id;
        }

        /******* Methods *******/

        public string dictKey()
        {
            return null;
        }

        /******* Properties *******/
        public string First_name
        {
            get { return this.first_name; }
        }

        public string Last_name
        {
            get { return this.last_name; }
        }

        public int Id
        {
            get { return this.id; }
        }
    }
}
