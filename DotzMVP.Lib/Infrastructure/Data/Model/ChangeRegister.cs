using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Lib.Infrastructure.Data.Model
{
    public class ChangeRegister: ModelBase
    {
        public StatusChange Status { get; set; }
        public Guid CustomerID { get; set; }
        public Customer Customer { get; set; }
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
    }

    public enum StatusChange 
    {
        Waiting,
        Approved,
        Rejected,
        Closed
    }

}
