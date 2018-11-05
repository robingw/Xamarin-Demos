using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace DBDemo.Database
{
    public interface ITableController<T> where T : ITableModel
    {
        void SetSQLiteAsyncConnection(SQLiteAsyncConnection database);

        // 获取所有记录
        Task<List<T>> GetItemsAsync();
        // 按条件获取记录
        Task<List<T>> GetItemsWithConditionAsync(string key, string value);
        // 根据id获取记录
        Task<T> GetItemAsync(int id);
        // 根据排序获取记录
        Task<List<T>> GetItemByASCAsync(int index, int count);
        Task<List<T>> GetItemByDESCAsync(int index, int count);
        // 保存一条记录
        Task<int> SaveItemAsync(T item);
        // 根据id删除记录
        Task<int> DeleteItemAsync(int id);
        // 清空表
        Task EmptyItemsAsync();
    }
}
