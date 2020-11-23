using DotzMVP.Lib.Exceptions;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Infrastructure.Data.Repository;
using DotzMVP.Lib.Infrastructure.Validator;
using DotzMVP.Lib.Services.CustomerService;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Services.UserAdminService
{
    public class UserAdminService : IUserAdminService
    {
        private readonly IRepository<UserAdmin> _userRepository;
        private readonly ICustomerService _customerService;
        public UserAdminService(IRepository<UserAdmin> userRepository, ICustomerService customerService)
        {
            _userRepository = userRepository;
            _customerService = customerService;
        }
        public async Task<UserAdmin> CreateAsync(UserAdmin item)
        {
            await ValidateUserAdminAsync(item);
            return await _userRepository.CreateAsync(item);
        }

        public async Task<List<UserAdmin>> GetByFilterAsync(Expression<Func<UserAdmin, bool>> filter, List<Expression<Func<UserAdmin, object>>> including = null)
        {
            return await _userRepository.GetByFilterAsync(filter, including);
        }

        public Task<UserAdmin> GetByIdAsync(Guid id, List<Expression<Func<UserAdmin, object>>> including = null)
        {
            return _userRepository.GetByIdAsync(id, including);
        }

        public async Task<UserAdmin> UpdateAsync(UserAdmin item)
        {
            return await _userRepository.UpdateAsync(item);
        }
        private async Task ValidateUserAdminAsync(UserAdmin item)
        {
            Expression<Func<UserAdmin, bool>> filter = x => x.IsDeleted == false && x.Email.Equals(item.Email);
            var user = await GetByFilterAsync(filter);
            if (user.Count > 0)
                throw new ArgumentException("Email existis in database.");
            var validator = new PersonValidator();
            validator.ValidateAndThrow(item);
        }
    }
}
