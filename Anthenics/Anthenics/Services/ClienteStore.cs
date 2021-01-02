using Anthenics.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Anthenics.Services
{
    public class ClienteStore : IClienteStore
    {
        private readonly SQLiteAsyncConnection connection;
        public ClienteStore()
        {
            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            //connection = db.GetConnection();
            connection.CreateTableAsync<Cliente>();
        }

        public async Task AddCliente(Cliente cliente)
        {
            await connection.InsertAsync(cliente);
        }

        public async Task DeleteCliente(Cliente cliente)
        {
            await connection.DeleteAsync(cliente);
        }

        public async Task<Cliente> GetCliente(int id)
        {
            return await connection.FindAsync<Cliente>(id);
        }

        public async Task<IEnumerable<Cliente>> GetClientiAsync()
        {
            return await connection.Table<Cliente>().ToListAsync();
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            await connection.UpdateAsync(cliente);
        }
    }
}
