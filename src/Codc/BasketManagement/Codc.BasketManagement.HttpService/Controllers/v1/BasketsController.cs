using Codc.BasketManagement.Application.InputModels;
using Codc.BasketManagement.Domain.Repositories;
using Codc.BasketManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Codc.BasketManagement.HttpService.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BasketsController : BaseController
    {
        protected IBasketRepository BasketRepository
        {
            get
            {
                return new MemoryBasketRepository(this.UserId);
            }
        }

        [HttpPost]
        public ActionResult AddItem(BasketAddItemInputModel item)
        {
            this.BasketRepository.Add(item.ProductId, item.Amount ?? 1);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateItem(BasketUpdateItemInputModel item)
        {
            this.BasketRepository.Update(item.ProductId, item.Amount);
            return Ok();
        }

        [HttpDelete("products/{productId}")]
        public ActionResult RemoveItem(int productId)
        {
            this.BasketRepository.Remove(productId);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult ClearBasket()
        {
            this.BasketRepository.Clear();
            return NoContent();
        }
    }
}
