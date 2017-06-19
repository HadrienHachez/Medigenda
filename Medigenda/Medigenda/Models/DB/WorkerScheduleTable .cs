using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
namespace Medigenda
{
    public class WorkerScheduleTable
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Output { get; set; }
        public string Color { get; set; }
        public string BeginHour { get; set; }
        public string EndHour { get; set; }
    }
}
