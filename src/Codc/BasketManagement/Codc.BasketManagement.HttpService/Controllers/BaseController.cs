using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Codc.BasketManagement.HttpService.Controllers
{
    [Authorize]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected string UserId
        {
            get
            {
                return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
        }
    }
}
