using DBDemo.Database;
using SQLite;

namespace DB.Services.DatabaseService.Model
{
    public class TestTable : ITableModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
