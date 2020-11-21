using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Lib.Infrastructure.Data.Model
{
    public class Product: ModelBase
    {
        public double Price { get; set; }
        public string Resume { get; set; }
        public string Descrption { get; set; }
        public Guid CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
