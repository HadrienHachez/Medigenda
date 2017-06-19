using SQLite.Net.Attributes;
namespace Medigenda
{
    public class ShiftTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int FKService { get; set; }
        public string Start_hour { get; set; }
        public string End_hour { get; set; }
        public int Minwo { get; set; }
        public int Optwo { get; set; }
        public int mon { get; set; }
        public int tue { get; set; }
        public int wed { get; set; }
        public int thu { get; set; }
        public int fri { get; set; }
        public int sat { get; set; }
        public int sun { get; set; }
    }
}
