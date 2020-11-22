using DotzMVP.Lib.Exceptions;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> CreateAsync(User user)
        {
            return await _userRepository.CreateAsync(user);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> UpdateAddressAsync(User user)
        {
            var userData = await GetByIdAsync(user.Id);

            if (userData == null)
                throw new NotFoundException("User Not Found");

            if (userData.AddressID == null)
                userData.Address = new Address();

            userData.Address.ZipCode = user.Address.ZipCode;
            userData.Address.Street = user.Address.Street;
            userData.Address.Number = user.Address.Number;
            userData.Address.Complement = user.Address.Complement;
            userData.Address.Neighborhood = user.Address.Neighborhood;
            userData.Address.City = user.Address.City;
            userData.Address.State = user.Address.State;

            return await UpdateAsync(userData);
        }

        public async Task<User> UpdateAsync(User item)
        {
            return await _userRepository.UpdateAsync(item);
        }
    }
}
