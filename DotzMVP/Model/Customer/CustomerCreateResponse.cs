using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotzMVP.Model.Customer
{
    public class CustomerCreateResponse
    {
        public Guid Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string FantasyName { get; set; }
    }
}
