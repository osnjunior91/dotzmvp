using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotzMVP.Model.User
{
    public class UserRegisterScoreResponse
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public Guid PersonID { get; set; }
        public Guid CustomerID { get; set; }
    }
}
