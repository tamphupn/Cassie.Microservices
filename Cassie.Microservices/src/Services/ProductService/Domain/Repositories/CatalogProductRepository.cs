﻿using Cassie.Contracts.Domains.Repositories;
using Cassie.SharedInfrastructure.Domains.Repositories;
using ProductService.Domain.Entities;
using ProductService.Domain.Repositories.Interfaces;
using ProductService.Persistence;

namespace ProductService.Domain.Repositories
{
	public class CatalogProductRepository : RepositoryBase<CatalogProduct, long, ProductDbContext>, ICatalogProductRepository
    {
		public CatalogProductRepository(ProductDbContext context, IUnitOfWork<ProductDbContext> uow): base(context, uow)
		{
		}
	}
}