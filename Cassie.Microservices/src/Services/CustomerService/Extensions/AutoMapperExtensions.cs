using AutoMapper;
using Cassie.SharedApplication.Extensions;
using CustomerService.Application.Customers.Dtos;
using CustomerService.Domain.Entities;

namespace CustomerService.Extensions
{
	public class AutoMapperExtensions: Profile
	{
		public AutoMapperExtensions()
		{
			CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>()
                .IgnoreNoneExistedProperties();
        }
	}
}