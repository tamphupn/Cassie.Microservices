using System;
using BasketService.Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;

namespace BasketService.Domain.IRepositories
{
    public interface IBasketRepository
    {
        Task<Cart?> GetBasketByUserName(string username);
        Task<Cart?> UpdateBasket(Cart cart, DistributedCacheEntryOptions? options = null);
        Task<bool> DeleteBasketFromUserName(string username);
    }
}

