using Bogus;
using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotzMVP.Test.Factory
{
    public static class ChangeRegisterFactory
    {
        public static ChangeRegister Single()
        {
            var user = UserFactory.Single();

            return new Faker<ChangeRegister>()
                .RuleFor(x => x.Id, p => p.Random.Guid())
                .RuleFor(x => x.Status, StatusChange.Rejected)
                .RuleFor(x => x.Itens, ChangeRegisterItemFactory.List())
                .RuleFor(x => x.Person, user)
                .RuleFor(x => x.PersonID, user.Id)
                .Generate();
        }
    }
}
