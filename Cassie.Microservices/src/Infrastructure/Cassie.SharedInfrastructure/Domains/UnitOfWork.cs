using Cassie.Contracts.Domains.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cassie.SharedInfrastructure.Domains
{
	public class UnitOfWork<TContext>: IUnitOfWork<TContext> where TContext: DbContext
	{
        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<int> CommitAsync() => _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}

