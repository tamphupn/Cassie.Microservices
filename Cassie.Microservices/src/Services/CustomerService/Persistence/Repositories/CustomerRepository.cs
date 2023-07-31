using Cassie.Contracts.Domains.Repositories;
using Cassie.SharedInfrastructure.Domains.Repositories;
using CustomerService.Domain.Entities;
using CustomerService.Domain.IRepositories;

namespace CustomerService.Persistence.Repositories
{
	public class CustomerRepository: RepositoryBase<Customer, int, CustomerDbContext>, ICustomerRepository
    {
        public CustomerRepository(CustomerDbContext context, IUnitOfWork<CustomerDbContext> uow): base(context, uow)
		{
		}
	}
}

