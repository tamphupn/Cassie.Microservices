using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Cassie.Contracts.Domains.Repositories
{
	public interface IRepositoryQueryBase<T, K>
		where T: EntityBase<K>
	{
		IQueryable<T> FindAll(bool trackChange = false);
		IQueryable<T> FindAll(bool trackChange = false, params Expression<Func<T, object>>[] includeProperties);
		IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChange = false);
	}

    public interface IRepositoryQueryBase<T, K, TContext>
        where T : EntityBase<K>
        where TContext: DbContext
    {
        IQueryable<T> FindAll(bool trackChange = false);
        IQueryable<T> FindAll(bool trackChange = false, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChange = false);
    }
}