using SQLite.Net.Attributes;
namespace Medigenda
    {
    public class ServiceTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
