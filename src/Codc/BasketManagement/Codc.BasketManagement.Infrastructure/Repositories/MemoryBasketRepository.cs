using Codc.BasketManagement.Domain.Models;
using Codc.BasketManagement.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Codc.BasketManagement.Infrastructure.Repositories
{
    public class MemoryBasketRepository : IBasketRepository
    {
        private static Dictionary<Guid, Basket> userBaskets =
            new Dictionary<Guid, Basket>();
        private Basket userBasket;

        public MemoryBasketRepository(Guid userId)
        {
            if (userBaskets.TryGetValue(userId, out Basket userBasket))
            {
                this.userBasket = userBasket;
            }
            else
            {
                this.userBasket = new Basket();
                userBaskets[userId] = this.userBasket;
            }
        }

        public void Add(int productId, int amount)
        {
            this.userBasket.Add(productId, amount);
        }

        public void Update(int productId, int amount)
        {
            this.userBasket.Update(productId, amount);
        }

        public void Remove(int productId)
        {
            this.userBasket.Remove(productId);
        }

        public void Clear()
        {
            this.userBasket.Clear();
        }
    }
}
