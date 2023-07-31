using System;
using Cassie.Contracts.Domains.Repositories;
using Cassie.SharedInfrastructure.Domains.Repositories;
using CustomerService.Domain.Entities;
using CustomerService.Persistence;

namespace CustomerService.Domain.IRepositories
{
	public interface ICustomerRepository: IRepositoryBase<Customer, int, CustomerDbContext>
	{
	}
}

