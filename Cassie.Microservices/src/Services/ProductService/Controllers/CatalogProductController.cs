using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Dtos;
using ProductService.Domain.IRepositories;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogProductController: ControllerBase
	{
		private readonly ICatalogProductRepository _catalogProductRepository;

        public CatalogProductController(ICatalogProductRepository catalogProductRepository)
		{
            _catalogProductRepository = catalogProductRepository ?? throw new ArgumentNullException(nameof(catalogProductRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _catalogProductRepository.GetAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]CatalogProductCreateDto model)
        {
            var newId = await _catalogProductRepository.CreateAsync(model);
            if (newId > 0) return new CreatedResult(nameof(CreateAsync), newId);
            return BadRequest();
        }

        //[HttpDelete]
        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    var result = await _catalogProductRepository.DeleteAsync(id);
        //    if (result == null) return NotFound();
        //    return Ok(result);
        //}
    }
}