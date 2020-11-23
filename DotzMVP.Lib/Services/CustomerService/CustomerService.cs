using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Infrastructure.Data.Repository;
using DotzMVP.Lib.Infrastructure.Validator;
using FluentValidation;
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
            var validator = new CustomerValidator();
            validator.ValidateAndThrow(item);
            return await _customerRepository.CreateAsync(item);
        }
        public async Task<List<Customer>> GetByFilterAsync(Expression<Func<Customer, bool>> filter, List<Expression<Func<Customer, object>>> including = null)
        {
            return await _customerRepository.GetByFilterAsync(filter, including);
        }

        public async Task<Customer> GetByIdAsync(Guid id, List<Expression<Func<Customer, object>>> including = null)
        {
            return await _customerRepository.GetByIdAsync(id, including);
        }

        public async Task<Customer> UpdateAsync(Customer item)
        {
            return await _customerRepository.UpdateAsync(item);
        }
    }
}
