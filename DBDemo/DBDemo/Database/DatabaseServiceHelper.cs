using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace DBDemo.Database
{
    public class DatabaseHelper<T, V> where T : ITableController<V> 
                                      where V : ITableModel
    {
        readonly SQLiteAsyncConnection database;
        private T controller;

        public DatabaseHelper(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            controller = (T)System.Activator.CreateInstance<T>();
            controller.SetSQLiteAsyncConnection(database);
        }

        // 获取所有记录
        public Task<List<V>> GetItemsAsync() => controller.GetItemsAsync();

        // 按条件获取记录
        public Task<List<V>> GetItemsWithConditionAsync(string key, string value) => controller.GetItemsWithConditionAsync(key, value);

        // 根据id获取记录
        public Task<V> GetItemAsync(int id) => controller.GetItemAsync(id);

        // 根据排序获取记录
        public Task<List<V>> GetItemByASCAsync(int index, int count) => controller.GetItemByASCAsync(index, count);
        public Task<List<V>> GetItemByDESCAsync(int index, int count) => controller.GetItemByDESCAsync(index, count);

        // 保存一条记录
        public Task<int> SaveItemAsync(V item) => controller.SaveItemAsync(item);

        // 根据id删除记录
        public Task<int> DeleteItemAsync(V item) => controller.DeleteItemAsync(item);

        // 清空表
        public Task EmptyItemsAsync() => controller.EmptyItemsAsync();
    }
}

