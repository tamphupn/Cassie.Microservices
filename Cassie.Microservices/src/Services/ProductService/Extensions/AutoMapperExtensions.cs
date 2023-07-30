using AutoMapper;
using ProductService.Application.CatalogProducts.Dtos;
using ProductService.Domain.Entities;

namespace ProductService.Extensions
{
	public class AutoMapperExtensions: Profile
	{
		public AutoMapperExtensions()
		{
			CreateMap<CatalogProduct, CatalogProductDto>();
		}
	}
}

