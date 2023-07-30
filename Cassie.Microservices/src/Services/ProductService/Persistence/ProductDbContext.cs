using Cassie.Contracts.Domains.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;

namespace ProductService.Persistence
{
	public class ProductDbContext: DbContext
	{
		public DbSet<CatalogProduct> CatalogProducts { get; set; }

		public ProductDbContext(DbContextOptions<ProductDbContext> options = default!): base (options)
		{
			if (options == null)
			{
				throw new ArgumentNullException(nameof(options));
			}
		}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
			var entityStates = new List<EntityState>() { EntityState.Modified, EntityState.Added, EntityState.Deleted };

			var modifiedEntity = ChangeTracker.Entries()
				.Where(x => entityStates.Contains(x.State));

			foreach (var entity in modifiedEntity)
			{
				switch (entity.State)
				{
					case EntityState.Added:
						if (entity.Entity is IDateTracking addedEntity)
						{
							addedEntity.CreatedDate = DateTimeOffset.Now;
							entity.State = EntityState.Added;
						}
						break;
					case EntityState.Modified:		
						Entry(entity.Entity).Property("Id").IsModified = false;
						if (entity.Entity is IDateTracking modifyEntity)
						{
                            modifyEntity.LastModifiedDate = DateTimeOffset.Now;
							entity.State = EntityState.Modified;
						}
						break;
				}
			}
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

