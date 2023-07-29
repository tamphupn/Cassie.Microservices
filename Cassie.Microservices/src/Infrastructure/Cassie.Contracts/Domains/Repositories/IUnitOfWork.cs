using Microsoft.EntityFrameworkCore;

namespace Cassie.Contracts.Domains.Repositories
{
	public interface IUnitOfWork<TContext>: IDisposable where TContext: DbContext
	{
		Task<int> CommitAsync();
	}
}