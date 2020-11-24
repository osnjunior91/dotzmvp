using Bogus;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Infrastructure.Data.Repository;
using DotzMVP.Lib.Services.ScoreService;
using DotzMVP.Lib.Services.UserService;
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
    public class UserServiceTest
    {
        Mock<IRepository<User>> _repository = new Mock<IRepository<User>>();
        Mock<IScoreService> _scoreService = new Mock<IScoreService>();
        [Fact]
        public async Task UpdateScore()
        {
            var faker = new Faker("pt_BR");
            var score = faker.Random.Double(350, 3500);
            var user = UserFactory.Single();
            _repository.Setup(m => m.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<List<Expression<Func<User, object>>>>())).ReturnsAsync(user);
            _repository.Setup(m => m.UpdateAsync(It.IsAny<User>())).ReturnsAsync(user);
            UserService userService = new UserService(_repository.Object, _scoreService.Object);
            var result = await userService.UpdateScoreAsync(user.Id, score);
            Assert.Equal(result.TotalScore, score);
        }
    }
}
