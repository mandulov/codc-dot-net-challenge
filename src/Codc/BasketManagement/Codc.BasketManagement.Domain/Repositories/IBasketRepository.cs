using Codc.BasketManagement.Domain.Models;
using System.Collections.Generic;

namespace Codc.BasketManagement.Domain.Repositories
{
    public interface IBasketRepository
    {
        void Add(int productId, int amount);
        void Update(int productId, int amount);
        void Remove(int productId);
        void Clear();
        IEnumerable<BasketItem> View();
    }
}
