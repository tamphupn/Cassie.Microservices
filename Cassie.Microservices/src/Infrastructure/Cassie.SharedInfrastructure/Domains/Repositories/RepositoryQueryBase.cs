using System.Linq.Expressions;
using Cassie.Contracts.Domains;
using Cassie.Contracts.Domains.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cassie.SharedInfrastructure.Domains.Repositories
{
	public class RepositoryQueryBase<T, K>
		where T: EntityBase<K>
	{
	}

    public class RepositoryQueryBase<T, K, TDbContext> : RepositoryQueryBase<T, K>, IRepositoryQueryBase<T, K, TDbContext>
        where T : EntityBase<K>
        where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        public RepositoryQueryBase(TDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<T> FindAll(bool trackChange = false) =>
            trackChange ? _context.Set<T>() : _context.Set<T>().AsNoTracking();

        public IQueryable<T> FindAll(bool trackChange = false, params Expression<Func<T, object>>[] includeProperties)
        {
            var records = FindAll(trackChange);
            records = includeProperties.Aggregate(records, (current, includeProperty) => current.Include(includeProperty));
            return records;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChange = false) =>
            trackChange ? _context.Set<T>().Where(expression) : _context.Set<T>().Where(expression).AsNoTracking();
    }
}

