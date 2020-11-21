using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Lib.Infrastructure.Data.Model
{
    public class UserAdmin : Person
    {
        public Guid CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
