using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Codc.BasketManagement.HttpService.Controllers
{
    [Authorize]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected Guid UserId
        {
            get
            {
                return Guid.Parse(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            }
        }
    }
}
