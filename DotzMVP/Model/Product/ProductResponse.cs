using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotzMVP.Model.Product
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public string Resume { get; set; }
        public string Descrption { get; set; }
        public Guid CustomerID { get; set; }
    }
}
