using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/** Packages à installer **/
using System.Windows.Forms;

namespace Medigenda
{
    class Program
    {


        static void Main(string[] args)
        {
            DateTime today = new DateTime(2017, 03, 06, 10, 03, 28);
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
            Console.WriteLine(DateTime.Now.ToString("dd/mm/yy HH:mm"));

            Console.ReadKey();
        }
    }
}
