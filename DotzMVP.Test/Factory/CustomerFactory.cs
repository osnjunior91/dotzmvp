using Bogus;
using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Test.Factory
{
    public static class CustomerFactory
    {
        public static Customer Single()
        {
            return new Faker<Customer>("pt_BR")
                .RuleFor(x => x.Id, p => p.Random.Guid())
                .RuleFor(x => x.FantasyName, p => p.Company.CompanyName())
                .RuleFor(x => x.Email, p => p.Internet.Email())
                .RuleFor(x => x.Email, p => p.Phone.PhoneNumber())
                .RuleFor(x => x.FantasyName, p => p.Company.CompanyName())
                .RuleFor(x => x.RegistrationNumber, "58022451000100")
                .Generate();
        }
    }
}
