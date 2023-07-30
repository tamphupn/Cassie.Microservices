using System.Linq.Expressions;
using Cassie.Contracts.Domains;
using Cassie.Contracts.Domains.Repositories;

namespace Cassie.SharedInfrastructure.Domains.Repositories
{
	public class RepositoryQueryBase<T, K>
		where T: EntityBase<K>
	{
	}

    //public class RepositoryQueryBase<T, K, TDbContext> : RepositoryBase<T, K>, IRepositoryQueryBase<T, K, TDbContext>
    //    where T : EntityBase<K>
    //    where TDbContext : TDbContext
    //{
    //    private readonly TDbContext _context;

    //    public RepositoryQueryBase(TDbContext context)
    //    {
    //        _context = context ?? throw new ArgumentNullException(nameof(context));
    //    }

    //    public IQueryable<T> FindAll(bool trackChange = false) =>
    //        trackChange ? _context.Set<T>() : _context.Set<T>().AsNoTracking();

    //    public IQueryable<T> FindAll(bool trackChange = false, params Expression<Func<T, object>>[] includeProperties)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChange = false)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}

