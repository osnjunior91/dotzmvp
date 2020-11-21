using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Lib.Infrastructure.Data.Model
{
    public class Score: ModelBase
    {
        public double Amount { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }
        public Guid CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
