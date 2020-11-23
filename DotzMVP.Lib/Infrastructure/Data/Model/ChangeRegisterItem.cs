using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Lib.Infrastructure.Data.Model
{
    public class ChangeRegisterItem : ModelBase
    {
        public double Price { get; set; }
        public int Amount { get; set; }
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
    }
}
