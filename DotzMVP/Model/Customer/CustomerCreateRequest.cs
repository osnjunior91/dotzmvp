using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotzMVP.Model.Customer
{
    public class CustomerCreateRequest
    {
        public string RegistrationNumber { get; set; }
        public string FantasyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
