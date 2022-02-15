using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinBmi.Utils
{
    public class BmiDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public BmiDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<BmiData>().Wait();
        }

        public Task<List<BmiData>> GetBMIs()
        {
            return _database.Table<BmiData>().OrderByDescending(x => x.ID).ToListAsync();
        }

        public Task<int> SaveNewRecord(BmiData Data)
        {
            return _database.InsertAsync(Data);
        }

        public Task<int> ClearDB()
        {
            return _database.DeleteAllAsync<BmiData>();
        }
    }
}
