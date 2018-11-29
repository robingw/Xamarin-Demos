using System.Collections.Generic;
using System.Threading.Tasks;
using DB.Services.DatabaseService.Model;
using SQLite;

namespace DBDemo.Database.Controller
{
    public class TestTableController : ITableController<TestTable>
    {
        private SQLiteAsyncConnection database;

        public void SetSQLiteAsyncConnection(SQLiteAsyncConnection database)
        {
            this.database = database;
            database.CreateTableAsync<TestTable>().Wait();
        }

        public Task<List<TestTable>> GetItemsAsync() => database.Table<TestTable>().ToListAsync();

        public Task<List<TestTable>> GetItemsWithConditionAsync(string key, string value) => database.QueryAsync<TestTable>("SELECT * FROM [TestTable] WHERE [" + key + "] = '" + value + "'");

        public Task<TestTable> GetItemAsync(int id) => database.Table<TestTable>().Where(i => i.ID == id).FirstOrDefaultAsync();

        public Task<List<TestTable>> GetItemByASCAsync(int index, int count) => null;
        public Task<List<TestTable>> GetItemByDESCAsync(int index, int count) => null;

        public Task<int> SaveItemAsync(TestTable item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(TestTable item) => database.DeleteAsync(item);

        public Task EmptyItemsAsync() => null;
    }
}
