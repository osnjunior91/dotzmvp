using Bogus;
using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotzMVP.Test.Factory
{
    public class ChangeRegisterItemFactory
    {
        public static ChangeRegisterItem Single()
        {
            return new Faker<ChangeRegisterItem>()
                .RuleFor(x => x.Id, p => p.Random.Guid())
                .RuleFor(x => x.ProductID, p => p.Random.Guid())
                .RuleFor(x => x.Price, p => p.Random.Double(100.00, 1000.00))
                .RuleFor(x => x.Amount, p => p.Random.Int(1, 3)).Generate();
        }

        public static List<ChangeRegisterItem> List()
        {
            var product = ProductFactory.Single();
            return new Faker<ChangeRegisterItem>()
                .RuleFor(x => x.Id, p => p.Random.Guid())
                .RuleFor(x => x.ProductID, product.Id)
                .RuleFor(x => x.Product, product)
                .RuleFor(x => x.Price, p => product.Price)
                .RuleFor(x => x.Amount, p => p.Random.Int(1, 3))
                .GenerateLazy(3).ToList();
        }
    }
}
