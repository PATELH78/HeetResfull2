using Heetapp1.Interfaces;
using Heetapp1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heetapp1.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _customerRepo.GetAllCustomers();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _customerRepo.GetCustomerById(id);
        }

        public async Task AddCustomer(Customer customer)
        {
            await _customerRepo.AddCustomer(customer);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            await _customerRepo.UpdateCustomer(customer);
        }

        public async Task DeleteCustomer(int id)
        {
            await _customerRepo.DeleteCustomer(id);
        }
    }
}
