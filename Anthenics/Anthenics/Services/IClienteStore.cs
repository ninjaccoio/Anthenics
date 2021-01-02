using Anthenics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anthenics.Services
{
    public interface IClienteStore
    {
        Task<IEnumerable<Cliente>> GetClientiAsync();
        Task<Cliente> GetCliente(int id);
        Task AddCliente(Cliente cliente);
        Task UpdateCliente(Cliente cliente);
        Task DeleteCliente(Cliente cliente);
    }
}
