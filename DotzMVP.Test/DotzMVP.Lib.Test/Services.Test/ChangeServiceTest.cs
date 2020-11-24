using Bogus;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Infrastructure.Data.Repository;
using DotzMVP.Lib.Services.ChangeService;
using DotzMVP.Lib.Services.ProductService;
using DotzMVP.Lib.Services.UserService;
using DotzMVP.Test.Factory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace DotzMVP.Test.DotzMVP.Lib.Test.Services.Test
{
    public class ChangeServiceTest
    {
        Mock<IRepository<ChangeRegister>> _repository = new Mock<IRepository<ChangeRegister>>();
        Mock<IUserService> _userService = new Mock<IUserService>();
        Mock<IProductService> _productService = new Mock<IProductService>();


        [Fact]
        public async Task ChangeCreatedAsync()
        {
            var itemRegister = ChangeRegisterFactory.Single();
            var totalScore = itemRegister.Person.TotalScore;
            itemRegister.Person.TotalScore += itemRegister.Itens.Select(x => (x.Price * x.Amount)).ToList().Sum();

            _userService.Setup(m => m.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<List<Expression<Func<User, object>>>>())).ReturnsAsync((User)itemRegister.Person);
            _userService.Setup(m => m.UpdateScoreAsync(It.IsAny<Guid>(), It.IsAny<double>())).ReturnsAsync((User)itemRegister.Person);

            _repository.Setup(m => m.CreateAsync(It.IsAny<ChangeRegister>())).ReturnsAsync(itemRegister);

            ChangeService changeService = new ChangeService(_repository.Object, _userService.Object, _productService.Object);

            foreach (var item in itemRegister.Itens)
            {
                _productService.Setup(m => m.GetByIdAsync(item.ProductID, It.IsAny<List<Expression<Func<Product, object>>>>())).ReturnsAsync(item.Product);
            }

            var result = await changeService.CreateAsync(itemRegister);

            Assert.Equal((int)totalScore, (int)itemRegister.Person.TotalScore);
            Assert.Equal(StatusChange.Waiting, itemRegister.Status);
        }

        [Fact]
        public async Task UpdateStatusAsync()
        {
            var itemRegister = ChangeRegisterFactory.Single();
            _repository.Setup(m => m.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<List<Expression<Func<ChangeRegister, object>>>>())).ReturnsAsync(itemRegister);
            _repository.Setup(m => m.UpdateAsync(It.IsAny<ChangeRegister>())).ReturnsAsync(itemRegister);
            ChangeService changeService = new ChangeService(_repository.Object, _userService.Object, _productService.Object);

            var result = await changeService.UpdateStatusAsync(itemRegister.Id, StatusChange.Approved);

            Assert.Equal(StatusChange.Approved, result.Status);
        }

    }
}
