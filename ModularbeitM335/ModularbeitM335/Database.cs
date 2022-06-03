using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace ModularbeitM335
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Game>();
        }

        public Task<List<Game>> GetPeopleAsync()
        {
            return _database.Table<Game>().OrderByDescending(Game => Game.id).ToListAsync();

            
        }

        public Task<int> SavePersonAsync(Game person)
        {
            return _database.InsertAsync(person);
        }
    }
}