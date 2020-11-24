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
            return new Faker<Product>()
                .RuleFor(x => x.Id, p => p.Random.Guid())
                .RuleFor(x => x.Price, p => p.Random.Double(1, 300))
                .RuleFor(x => x.Resume, p => p.Commerce.ProductName())
                .RuleFor(x => x.Descrption, p => p.Commerce.ProductDescription())
                .Generate();
        }
    }
}
