using System;
using CustomerService.Domain.IRepositories;

namespace CustomerService.Application.Customers.Services
{
	public class CustomerService: ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerService(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }
	}
}