using DotzMVP.Lib.Exceptions;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Infrastructure.Data.Repository;
using DotzMVP.Lib.Infrastructure.Validator;
using DotzMVP.Lib.Services.ScoreService;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IScoreService _scoreService;
        public UserService(IRepository<User> userRepository, IScoreService scoreService)
        {
            _userRepository = userRepository;
            _scoreService = scoreService;
        }
        public async Task<User> CreateAsync(User user)
        {
            Expression<Func<User, bool>> filter = x => x.IsDeleted == false && x.Email.Equals(user.Email, StringComparison.InvariantCultureIgnoreCase);
            var userResponse = await GetByFilterAsync(filter);
            if (user != null)
                throw new ArgumentException("Email existis in database.");
            var validator = new PersonValidator();
            validator.ValidateAndThrow(user);
            return await _userRepository.CreateAsync(user);
        }

        public async Task<List<User>> GetByFilterAsync(Expression<Func<User, bool>> filter, List<Expression<Func<User, object>>> including = null)
        {
            return await _userRepository.GetByFilterAsync(filter, including);
        }

        public async Task<User> GetByIdAsync(Guid id, List<Expression<Func<User, object>>> including = null)
        {
            return await _userRepository.GetByIdAsync(id, including);
        }

        public async Task<Score> RegisterScoreUserAsync(Score score)
        {
            try
            {
                await _userRepository.BeginTransactionAsync();
                var userData = await GetByIdAsync(score.PersonID, null);
                if (userData == null)
                    throw new NotFoundException("User Not Found");
                userData.TotalScore += score.Amount;
                var user = await _userRepository.UpdateAsync(userData);
                score = await _scoreService.CreateAsync(score);
                await _userRepository.CommitTransactionAsync();
                return score;
            }
            catch (Exception)
            {
                await _userRepository.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<User> UpdateAddressAsync(User user)
        {
            List<Expression<Func<User, object>>> includes = new List<Expression<Func<User, object>>>() 
            {
                x => x.Address
            };
            var userData = await GetByIdAsync(user.Id, includes);

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

        public async Task<User> UpdateScoreAsync(Guid userId, double score)
        {
            var userData = await GetByIdAsync(userId, null);
            if (userData == null)
                throw new NotFoundException("User Not Found");
            userData.TotalScore = score;
            return await UpdateAsync(userData);
        }
    }
}
