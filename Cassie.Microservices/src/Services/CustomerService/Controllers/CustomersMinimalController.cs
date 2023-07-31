using AutoMapper;
using CustomerService.Application.Customers.Dtos;
using CustomerService.Domain.Entities;
using CustomerService.Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
	public static class CustomersMinimalController
    {
		public static void MapCustomerAPIs(this WebApplication app)
		{
			app.MapGet("/api/customer", async (int id, ICustomerRepository _customerRepository, IMapper _mapper) =>
			{
                var result = await _customerRepository.GetAsync(id);
                if (result == null) return Results.NotFound();
                var mapped = _mapper.Map<Customer, CustomerDto>(result);
                return Results.Ok(mapped);
            });

            app.MapPost("/api/customer", async ([FromBody]CustomerCreateDto model, ICustomerRepository _customerRepository, IMapper _mapper) =>
            {
                var newId = await _customerRepository.CreateAsync(model);
                if (newId > 0) return Results.Created(nameof(CustomerCreateDto), newId);
                return Results.BadRequest();
            });

            app.MapDelete("/api/customer", async (int id, ICustomerRepository _customerRepository, IMapper _mapper) =>
            {
                var isSuccess = await _customerRepository.DeleteAsync(id);
                return isSuccess ? Results.Ok() : Results.NotFound();
            });

            app.MapPut("/api/customer", async (int id, [FromBody] CustomerUpdateDto model, ICustomerRepository _customerRepository, IMapper _mapper) =>
            {
                var existed = await _customerRepository.GetAsync(id, true);
                if (existed == null) return Results.NotFound();

                var updatedProduct = _mapper.Map(model, existed);
                await _customerRepository.UpdateAsync(updatedProduct);

                return Results.Ok(_mapper.Map<CustomerDto>(updatedProduct));
            });
        }
	}
}