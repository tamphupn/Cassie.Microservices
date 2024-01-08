using BasketService.Domain.Entities;
using BasketService.Domain.IRepositories;
using Cassie.Contracts.Applications;
using Microsoft.Extensions.Caching.Distributed;

namespace BasketService.Persistence.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger _logger;
        private readonly ICassieSerializeService _serializeService;

        public BasketRepository(IDistributedCache cache, ILogger<BasketRepository> logger, ICassieSerializeService serializeService)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serializeService = serializeService ?? throw new ArgumentNullException(nameof(serializeService));
        }

        public async Task<bool> DeleteBasketFromUserName(string username)
        {
            try
            {
                await _cache.RemoveAsync(username);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error DeleteBasketFromUserName: " + ex.Message);
                throw;
            }
        }

        public async Task<Cart?> GetBasketByUserName(string username)
        {
            var basket = await _cache.GetStringAsync(username);
            return string.IsNullOrEmpty(basket) ? null : _serializeService.Deserialize<Cart>(basket);
        }

        public async Task<Cart?> UpdateBasket(Cart cart, DistributedCacheEntryOptions? options = null)
        {
            if (options != null)
                await _cache.SetStringAsync(cart.Username,
                    _serializeService.Serialize(cart), options);
            else
                await _cache.SetStringAsync(cart.Username,
                    _serializeService.Serialize(cart));

            return await GetBasketByUserName(cart.Username);
        }
    }
}

