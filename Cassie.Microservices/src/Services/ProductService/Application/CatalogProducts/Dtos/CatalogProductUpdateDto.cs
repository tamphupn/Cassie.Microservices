using System;
using ProductService.Domain.Entities;

namespace ProductService.Application.CatalogProducts.Dtos
{
	public class CatalogProductUpdateDto
    {
        public string? No { get; set; }

        public string? Name { get; set; }

        public string? Summary { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }
    }
}