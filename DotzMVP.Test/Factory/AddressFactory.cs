using Bogus;
using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Test.Factory
{
    public class AddressFactory
    {
        public static Address Single()
        {
            var user = UserFactory.Single();

            return new Faker<Address>()
                .RuleFor(x => x.Id, p => p.Random.Guid())
                .RuleFor(x => x.Street, p => p.Address.StreetName())
                .RuleFor(x => x.Number, p => p.Address.BuildingNumber())
                .RuleFor(x => x.City, p => p.Address.City())
                .RuleFor(x => x.ZipCode, p => p.Address.ZipCode())
                .Generate();
        }
    }
}
