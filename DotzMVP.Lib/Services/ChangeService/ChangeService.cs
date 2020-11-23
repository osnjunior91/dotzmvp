using DotzMVP.Lib.Exceptions;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Infrastructure.Data.Repository;
using DotzMVP.Lib.Services.ProductService;
using DotzMVP.Lib.Services.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Services.ChangeService
{
    public class ChangeService : IChangeService
    {
        private readonly IRepository<ChangeRegister> _changeRepository;
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        public ChangeService(IRepository<ChangeRegister> changeRepository, IUserService userService, IProductService productService)
        {
            _changeRepository = changeRepository;
            _userService = userService;
            _productService = productService;
        }

        public async Task<ChangeRegister> CreateAsync(ChangeRegister item)
        {
            await ValidateChangeAsync(item);
            try
            {
                await _changeRepository.BeginTransactionAsync();
                item.Status = StatusChange.Waiting;
                item.Person.TotalScore -= item.Itens.Select(x => (x.Price * x.Amount)).ToList().Sum();
                item.Person = await _userService.UpdateScoreAsync(item.Person.Id, item.Person.TotalScore);
                item = await _changeRepository.CreateAsync(item);
                await _changeRepository.CommitTransactionAsync();
                return item;
            }
            catch (Exception)
            {
                await _changeRepository.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<List<ChangeRegister>> GetByFilterAsync(Expression<Func<ChangeRegister, bool>> filter, List<Expression<Func<ChangeRegister, object>>> including = null)
        {
            return await _changeRepository.GetByFilterAsync(filter, including);
        }

        public async Task<ChangeRegister> GetByIdAsync(Guid id, List<Expression<Func<ChangeRegister, object>>> including = null)
        {
            return await _changeRepository.GetByIdAsync(id, including);
        }

        public async Task<ChangeRegister> UpdateAsync(ChangeRegister item)
        {
            return await _changeRepository.UpdateAsync(item);
        }

        public async Task<ChangeRegister> UpdateStatusAsync(Guid changeId, StatusChange status)
        {
            var change = await GetByIdAsync(changeId);
            if (change == null)
                throw new NotFoundException("Change Register Not Found");
            change.Status = status;
            return await UpdateAsync(change);
        }

        private async Task ValidateChangeAsync(ChangeRegister item)
        {
            var user = await _userService.GetByIdAsync(item.PersonID);
            if (user == null)
                throw new NotFoundException("User Not Found");
            if (user.Address == null)
                throw new NotFoundException("Address User Not Found");
            item.Person = user;
            foreach (var changeRegister in item.Itens)
            {
                var changeItem = await _productService.GetByIdAsync(changeRegister.ProductID);
                if (changeItem == null)
                    throw new NotFoundException("Intem Change Not Found");
                changeRegister.Product = changeItem;
                changeRegister.Price = changeItem.Price;
            }
            var amount = item.Itens.Select(x => (x.Price * x.Amount)).ToList().Sum();
            if(amount > user.TotalScore)
            {
                throw new ArgumentException("Insufficient Balance");
            }
        }
    }
}
