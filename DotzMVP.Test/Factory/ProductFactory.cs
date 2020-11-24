using Bogus;
using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Test.Factory
{
    public class ProductFactory
    {
        public static Product Single()
        {
            var customer = CustomerFactory.Single();
            return new Faker<Product>()
                .RuleFor(x => x.Id, p => p.Random.Guid())
                .RuleFor(x => x.Price, p => p.Random.Double(1, 300))
                .RuleFor(x => x.Resume, p => p.Commerce.ProductName())
                .RuleFor(x => x.IsDeleted, false)
                .RuleFor(x => x.Descrption, p => p.Commerce.ProductDescription())
                .RuleFor(x => x.CustomerID, customer.Id)
                .RuleFor(x => x.Customer, customer)
                .Generate();
        }
    }
}
