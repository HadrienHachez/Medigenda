using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
namespace Medigenda
{
    public class WorkerTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Tima { get; set; }
        public string Skills { get; set; }
    }
}
