using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Add libraries
using System.IO;

namespace Medigenda
{
     //The singleton class generator creates the lists of data with the information in the database
    public class Generator
    {

        private static List<Worker> list_of_workers;
        private static Dictionary<int, Day> list_of_days;
        private static readonly Generator generator = new Generator();

        public static Generator getInstance()
        {
            return generator;
        }
        

        private Generator()
        {

        }
          
        /******* Methods *******/
        public static void genWorkers()
        {
            list_of_workers = new List<Worker>();
            string[] file = System.IO.File.ReadAllLines("../files/Worker.txt");

        }

        public static void genDays()
        {

        }
    }
}
