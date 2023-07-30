using Cassie.Contracts.Domains.Repositories;
using ProductService.Domain.Entities;
using ProductService.Persistence;

namespace ProductService.Domain.Repositories.Interfaces
{
	public interface ICatalogProductRepository: IRepositoryBase<CatalogProduct, long, ProductDbContext>
    {
	}
}

