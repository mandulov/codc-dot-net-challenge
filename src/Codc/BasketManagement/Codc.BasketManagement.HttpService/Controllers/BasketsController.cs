using Microsoft.AspNetCore.Mvc;

namespace Codc.BasketManagement.HttpService.Controllers
{
    [Route("api/[controller]")]
    public class BasketsController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Test()
        {
            return "Hello, World!";
        }
    }
}
