using AutoMapper;
using CustomerService.Application.Customers.Dtos;
using CustomerService.Domain.Entities;
using CustomerService.Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CustomersController: ControllerBase
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly IMapper _mapper;

		public CustomersController(ICustomerRepository customerRepository,
            IMapper mapper)
		{
			_customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

		[HttpGet("email")]
		public async Task<IActionResult> GetCustomerByEmailAsync(string email)
		{
			var customer = _customerRepository.FindByCondition(x => x.EmailAddress.Equals(email), false).FirstOrDefault();
			if (customer == null) return NotFound();

			return Ok(_mapper.Map<Customer, CustomerDto>(customer));
		}
	}
}

