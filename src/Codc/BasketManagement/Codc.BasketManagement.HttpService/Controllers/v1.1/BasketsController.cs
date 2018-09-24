using Codc.BasketManagement.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Codc.BasketManagement.HttpService.Controllers.v1_1
{
    [ApiVersion("1.1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BasketsController : v1.BasketsController
    {
        [HttpGet]
        public ActionResult<IEnumerable<BasketItem>> View()
        {
            return Ok(this.basketRepository.View());
        }
    }
}
