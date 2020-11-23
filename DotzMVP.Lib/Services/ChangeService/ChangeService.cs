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
            item.Status = StatusChange.Waiting;
            return await _changeRepository.CreateAsync(item);
        }

        public async Task<List<ChangeRegister>> GetByFilterAsync(Expression<Func<ChangeRegister, bool>> filter, List<Expression<Func<ChangeRegister, object>>> including = null)
        {
            return await _changeRepository.GetByFilterAsync(filter, including);
        }

        public async Task<ChangeRegister> GetByIdAsync(Guid id, List<Expression<Func<ChangeRegister, object>>> including = null)
        {
            return await _changeRepository.GetByIdAsync(id, including);
        }

        public Task<ChangeRegister> UpdateAsync(ChangeRegister item)
        {
            throw new NotImplementedException();
        }
        private async Task ValidateChangeAsync(ChangeRegister item)
        {
            var user = await _userService.GetByIdAsync(item.PersonID);
            if (user == null)
                throw new NotFoundException("Customer Not Found");
            item.Person = user;
            foreach (var changeRegister in item.Itens)
            {
                var changeItem = await _productService.GetByIdAsync(changeRegister.Id);
                if (changeItem == null)
                    throw new NotFoundException("Intem Change Not Found");
                changeRegister.Product = changeItem;
            }
            var amount = item.Itens.Select(x => (x.Price * x.Amount)).ToList().Sum();
            if(amount > user.TotalScore)
            {
                throw new ArgumentException("Insufficient Balance");
            }
        }
    }
}
