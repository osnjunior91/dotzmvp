using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Lib.Infrastructure.Data.Model
{
    public class User : ModelBase
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Address> Adresses { get;set;}
    }
}
