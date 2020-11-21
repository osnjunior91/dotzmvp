using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Lib.Infrastructure.Data.Model
{
    public class Customer : ModelBase
    {
        public string RegistrationNumber { get; set; }
        public string FantasyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
