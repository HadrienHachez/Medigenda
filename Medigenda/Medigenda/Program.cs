using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/** Packages à installer **/
//using System.Windows.Forms;

namespace Medigenda
{
    class Program
    {


        static void Main(string[] args)
        {
            /*DateTime today = new DateTime(2017, 03, 06, 10, 03, 28);
            Console.WriteLine("DateTime today = new DateTime(2017, 03, 06, 10, 03, 28);\n\n");
            Console.WriteLine("today.ToString('...')):\n");
            Console.WriteLine("     d - " + today.ToString("d"));
            Console.WriteLine("     D - " + today.ToString("D") + "\n");
            Console.WriteLine("     f - " + today.ToString("f"));
            Console.WriteLine("     F - " + today.ToString("F") + "\n");
            Console.WriteLine("     g - " + today.ToString("g"));
            Console.WriteLine("     G - " + today.ToString("G") + "\n");
            Console.WriteLine("     m - " + today.ToString("m"));
            Console.WriteLine("     M - " + today.ToString("M") + "\n");
            Console.WriteLine("     o - " + today.ToString("o"));
            Console.WriteLine("     O - " + today.ToString("O") + "\n");
            Console.WriteLine("     t - " + today.ToString("t"));
            Console.WriteLine("     T - " + today.ToString("T") + "\n");
            Console.WriteLine("     r - " + today.ToString("r"));
            Console.WriteLine("     R - " + today.ToString("R") + "\n");

            Console.WriteLine(today.ToLongDateString());

            Console.WriteLine("\n today.ToString(\"HH:mm\") :\n");
            Console.WriteLine(today.ToString("HH:mm"));

            Console.WriteLine("\nObtenir les infos système courantes -> DateTime.Now.ToString(\"dd / mm / yy HH: mm\") \n");
            Console.WriteLine(DateTime.Now.ToString("dd/mm/yy HH:mm"));*/





            /*** Services and shifts ***/
            ServiceName radio = new ServiceName("Radiologie");
            ServiceName urgences = new ServiceName("Urgences");
            ServiceName irm = new ServiceName("IRM");

            Service service_radio = new Service(radio);
            Service service_urgences = new Service(urgences);
            Service service_irm = new Service(irm);


            /*** Days ***/

            Dictionary<int, Day> dict_of_days = new Dictionary<int, Day>();

            List<Day> list_of_days = new List<Day>();

            Day day_1 = new Day("2017:03:12");

            list_of_days.Add(day_1);

            day_1.addService(service_radio);
            day_1.addService(service_irm);


            /*** Workers ***/
            Worker tom = new Worker("Tom", "Sel");
            Worker hadrien = new Worker("Hadrien", "Hachez");
            Worker marcin = new Worker("Marcin", "Kras");

            List<Worker> list_of_workers = new List<Worker>();
            list_of_workers.Add(tom);
            list_of_workers.Add(hadrien);
            list_of_workers.Add(marcin);

            tom.addSkill(radio);
            tom.addSkill(urgences);
            hadrien.addSkill(urgences);
            marcin.addSkill(irm);


            /*** Company ***/
            Company hospital = new Company("Hopital de Braine", list_of_workers, dict_of_days);



            ///////////////////////////////////////////////////////////////////////////////////////




            foreach (Worker wo in list_of_workers)
            {
                Console.WriteLine("First name: " + wo.First_name + "\nLast name: " + wo.Last_name + "\n");
                Console.Write("\tSkills: ");
                foreach(ServiceName service_name in wo.Skills)
                {
                    Console.Write(service_name.Service_name + "\t");
                }
                Console.WriteLine("\n");
            }

            foreach(Day day in list_of_days)
            {
                day.displayInfo();
            }

            Console.ReadKey();
        }
    }
}
