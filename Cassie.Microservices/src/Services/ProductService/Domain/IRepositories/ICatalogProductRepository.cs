using Cassie.Contracts.Domains.Repositories;
using ProductService.Domain.Entities;
using ProductService.Persistence;

namespace ProductService.Domain.IRepositories
{
	public interface ICatalogProductRepository: IRepositoryBase<CatalogProduct, long, ProductDbContext>
    {
	}
}

