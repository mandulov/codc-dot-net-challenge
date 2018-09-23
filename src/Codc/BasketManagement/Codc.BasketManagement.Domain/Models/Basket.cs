using Codc.BasketManagement.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Codc.BasketManagement.Domain.Models
{
    public class Basket
    {
        private List<BasketItem> items = new List<BasketItem>();

        public void Add(int productId, int amount)
        {
            try
            {
                BasketItem basketItem = Find(productId);
                basketItem.Amount += amount;
            }
            catch (ProductNotInCartException)
            {
                this.items.Add(new BasketItem()
                {
                    ProductId = productId,
                    Amount = amount,
                });
            }
        }

        public void Update(int productId, int amount)
        {
            BasketItem basketItem = Find(productId);
            basketItem.Amount = amount;
        }

        public void Remove(int productId)
        {
            BasketItem basketItem = Find(productId);
            this.items.Remove(basketItem);
        }

        public void Clear()
        {
            this.items.Clear();
        }

        private BasketItem Find(int productId)
        {
            BasketItem basketItem =
                this.items.SingleOrDefault(item => item.ProductId == productId);

            if (basketItem == null)
            {
                throw new ProductNotInCartException();
            }

            return basketItem;
        }
    }
}
