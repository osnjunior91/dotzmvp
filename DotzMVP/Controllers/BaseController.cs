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

    }
}
