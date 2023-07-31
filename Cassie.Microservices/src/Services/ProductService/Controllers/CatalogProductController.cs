using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.CatalogProducts.Dtos;
using ProductService.Domain.Entities;
using ProductService.Domain.IRepositories;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogProductController: ControllerBase
	{
		private readonly ICatalogProductRepository _catalogProductRepository;
        private readonly IMapper _mapper;

        public CatalogProductController(ICatalogProductRepository catalogProductRepository
            , IMapper mapper)
		{
            _catalogProductRepository = catalogProductRepository ?? throw new ArgumentNullException(nameof(catalogProductRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _catalogProductRepository.GetAsync(id);
            if (result == null) return NotFound();
            var mapped = _mapper.Map<CatalogProduct, CatalogProductDto>(result);
            return Ok(mapped);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]CatalogProductCreateDto model)
        {
            var newId = await _catalogProductRepository.CreateAsync(model);
            if (newId > 0) return new CreatedResult(nameof(CreateAsync), newId);
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isSuccess = await _catalogProductRepository.DeleteAsync(id);
            return isSuccess ? Ok() : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CatalogProductUpdateDto model)
        {
            var existed = await _catalogProductRepository.GetAsync(id, true);
            if (existed == null) return NotFound();

            var updatedProduct = _mapper.Map(model, existed);
            await _catalogProductRepository.UpdateAsync(updatedProduct);

            return Ok(_mapper.Map<CatalogProductDto>(updatedProduct));
        }
    }
}