using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotzMVP.Model.UserAdmin
{
    public class UserAdminCreateRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid CustomerID { get; set; }
    }
}
