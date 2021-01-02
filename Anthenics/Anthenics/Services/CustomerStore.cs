using Anthenics.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Anthenics.Services
{
    public class CustomerStore : ICustomerStore
    {
        private readonly SQLiteAsyncConnection connection;
        public CustomerStore()
        {
            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            connection.CreateTableAsync<Customer>();
        }

        public async Task AddUpdateCustomer(Customer customer)
        {
            if(customer.Id != 0)
                await connection.UpdateAsync(customer);
            else
                await connection.InsertAsync(customer);
        }

        public async Task DeleteCustomer(Customer customer)
        {
            await connection.DeleteAsync(customer);
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await connection.FindAsync<Customer>(id);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await connection.Table<Customer>().ToListAsync();
        }
    }
}
