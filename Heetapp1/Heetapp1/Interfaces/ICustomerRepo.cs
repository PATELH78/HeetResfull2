using Heetapp1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Heetapp1.Interfaces
{
    public interface ICustomerRepo
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(int id);
    }
}
