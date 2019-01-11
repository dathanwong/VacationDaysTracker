using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace VacationDaysTracker
{
    class DataAccess
    {
        readonly SQLiteAsyncConnection database;

        public DataAccess(string dbPath)
        {
            //Create new SQLite table
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Vacation>().Wait();
        }

        //Get all vacations
        public Task<List<Vacation>> GetVacations()
        {
            return database.Table<Vacation>().ToListAsync();
        }

        //Add new vacation
        public Task<int> AddVacationAsync(Vacation item)
        {
            if(item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        //Delete vacation
        public Task<int> DeleteVacationAsync(Vacation item)
        {
            return database.DeleteAsync(item);
        }

        //Delete all vacations
        public async void DeleteAllVacations()
        {
            List<Vacation> all = await GetVacations();
            foreach(Vacation vacay in all)
            {
                await DeleteVacationAsync(vacay);
            }
            
        }

    }
}
