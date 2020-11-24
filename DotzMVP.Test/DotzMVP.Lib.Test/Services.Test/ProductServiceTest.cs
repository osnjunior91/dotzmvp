using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Infrastructure.Data.Repository;
using DotzMVP.Lib.Services.CustomerService;
using DotzMVP.Lib.Services.ProductService;
using DotzMVP.Test.Factory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotzMVP.Test.DotzMVP.Lib.Test.Services.Test
{
    public class ProductServiceTest
    {
        Mock<IRepository<Product>> _repository = new Mock<IRepository<Product>>();
        Mock<ICustomerService> _customer = new Mock<ICustomerService>();
        [Fact]
        public async Task DeleteAsync()
        {
            var product = ProductFactory.Single();
            _repository.Setup(m => m.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<List<Expression<Func<Product, object>>>>())).ReturnsAsync(product);
            _repository.Setup(m => m.UpdateAsync(It.IsAny<Product>())).ReturnsAsync(product);
            _customer.Setup(m => m.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<List<Expression<Func<Customer, object>>>>())).ReturnsAsync(new Customer());
            ProductService service = new ProductService(_repository.Object, _customer.Object);
            var result = await service.DeleteAsync(product.Id);
            Assert.True(result.IsDeleted);
        }
    }
}
