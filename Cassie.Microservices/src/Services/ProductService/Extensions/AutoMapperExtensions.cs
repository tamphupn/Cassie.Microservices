using AutoMapper;
using Cassie.SharedApplication.Extensions;
using ProductService.Application.CatalogProducts.Dtos;
using ProductService.Domain.Entities;

namespace ProductService.Extensions
{
	public class AutoMapperExtensions: Profile
	{
		public AutoMapperExtensions()
		{
			CreateMap<CatalogProduct, CatalogProductDto>();
			CreateMap<CatalogProductUpdateDto, CatalogProduct>()
				.IgnoreNoneExistedProperties();
		}
	}
}