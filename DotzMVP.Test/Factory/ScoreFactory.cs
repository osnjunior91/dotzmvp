using Bogus;
using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Test.Factory
{
    public static class ScoreFactory
    {
        public static Score Single()
        {
            return new Faker<Score>()
                .RuleFor(x => x.Id, p => p.Random.Guid())
                .RuleFor(x => x.CustomerID, p => p.Random.Guid())
                .RuleFor(x => x.Amount, p => p.Random.Double(100, 200))
                .Generate();
        }
    }
}
