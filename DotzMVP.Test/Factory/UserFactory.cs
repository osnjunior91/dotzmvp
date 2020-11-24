using Bogus;
using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Test.Factory
{
    public static class UserFactory
    {
        public static User Single()
        {
            return new Faker<User>()
                .RuleFor(x => x.Id, p => p.Random.Guid())
                .RuleFor(x => x.Email, p => p.Internet.Email())
                .RuleFor(x => x.Name, p => p.Person.FullName)
                .RuleFor(x => x.Password, p => p.Internet.Password())
                .RuleFor(x => x.Discriminator, "User")
                .RuleFor(x => x.TotalScore, p => p.Random.Double(100, 1200))
                .RuleFor(x => x.Address, p => new Address())
                .Generate();
        }
    }
}
