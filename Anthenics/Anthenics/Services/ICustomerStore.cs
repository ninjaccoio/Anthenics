using Anthenics.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Anthenics.Services
{
    public interface ICustomerStore
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomer(int id);
        Task AddUpdateCustomer(Customer customer);
        Task DeleteCustomer(Customer customer);
    }
}
