using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer> CreateAsync(Customer item)
        {
            return await _customerRepository.CreateAsync(item);
        }

        public Task<List<Customer>> GetByFilterAsync(List<Expression<Func<Customer, bool>>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetByFilterAsync(Expression<Func<Customer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetByIdAsync(Guid id, List<Expression<Func<Customer, object>>> including = null)
        {
            return await _customerRepository.GetByIdAsync(id, including);
        }

        public Task<Customer> UpdateAsync(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
