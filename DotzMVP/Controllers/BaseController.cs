using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotzMVP.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected Guid CurrentUser 
        {
            get
            {
                var user = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Guid.Parse(user);
            }
            private set { }
        }

        protected UserType CurrentUserType
        {
            get
            {
                var role = User.FindFirst(ClaimTypes.Role).Value;
                return (UserType)Enum.Parse(typeof(UserType), role);
            }
            private set { }
        }

    }

    public enum UserType
    {
        UserAdmin,
        User
    }
}
