using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Infrastructure.Data.Repository;
using DotzMVP.Lib.Services.AuthService;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotzMVP.Test.DotzMVP.Lib.Test.Services.Test
{
    public class AuthServiceTest
    {
        [Fact]
        public async Task LoginTesteAsync()
        {

            var login = new Login()
            {
                Email = "test@test.com.br",
                Password = "123456"
            };
            var listPerson = new List<Person>()
            {
                new Person(){
                    Id = Guid.NewGuid(),
                    Name = "Test Login",
                    Email = "test@test.com.br",
                    Discriminator = "User"
                }

            };
            var Configuration = new Mock<IConfiguration>();
            Configuration.SetupGet(x => x[It.Is<string>(s => s == "SecretKey")]).Returns("DmSAzDlUXRak7hdXwY2em5sdKOmXz83F");
            var personRepository = new Mock<IRepository<Person>>();
            personRepository.Setup(m => m.GetByFilterAsync(It.IsAny<Expression<Func<Person, bool>>>(), null)).ReturnsAsync(listPerson);
            var authService = new AuthService(Configuration.Object, personRepository.Object);
            Assert.IsType<string>(await authService.AuthUserAsync(login));

        }
    }
}
