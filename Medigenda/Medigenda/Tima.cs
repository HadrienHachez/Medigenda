using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medigenda
{
    class Tima
    {
        private string name;
        private float factor;


        public Tima(string name, float factor)
        {
            this.name = name;
            this.factor = factor;
        }


        public string Name
        {
            get { return this.name; }
        }

        public float Factor
        {
            get { return this.factor; }
        }
    }
}
