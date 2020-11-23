using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Lib.Infrastructure.Data.Model
{
    public class Person: ModelBase
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Discriminator { get; set; }
        public double TotalScore { get; set; }
        public Guid? AddressID { get; set; }
        public Address Address { get; set; }
        public List<Score> Scores { get; set; }
    }
}
