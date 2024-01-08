using BasketService.Domain.Constants;
using BasketService.Domain.Entities;
using BasketService.Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.ComponentModel.DataAnnotations;

namespace BasketService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketsController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
        }

        [HttpGet]
        public async Task<ActionResult<Cart>> GetBasket([Required] string username)
        {
            var result = await _basketRepository.GetBasketByUserName(username);
            if (result == null) return new Cart(username);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Cart>> UpdateBasket([FromBody] Cart cart)
        {
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.UtcNow.AddHours(BasketConstants.BASKET_CACHE_TIME))
                .SetSlidingExpiration(TimeSpan.FromMinutes(BasketConstants.BASKET_CACHE_TIME));

            var result = await _basketRepository.UpdateBasket(cart, options);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasket([Required] string username)
        {
            var result = await _basketRepository.DeleteBasketFromUserName(username);
            return Ok(result);
        }
    }
}

