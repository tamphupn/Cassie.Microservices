using Cassie.Contracts.Domains;
using Cassie.Contracts.Domains.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Cassie.SharedInfrastructure.Domains.Repositories
{
	public class RepositoryBase<T, K>: RepositoryQueryBase<T, K> where T: EntityBase<K> { }

	public class RepositoryBase<T, K, TContext>: RepositoryQueryBase<T, K, TContext>, IRepositoryBase<T, K, TContext>
		where T: EntityBase<K>
		where TContext: DbContext
	{

        private readonly TContext _dbContext;
        private readonly IUnitOfWork<TContext> _unitOfWork;

		public RepositoryBase(TContext dbContext, IUnitOfWork<TContext> unitOfWork): base(dbContext)
		{
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<IDbContextTransaction> BeginTransactionAsync() => _dbContext.Database.BeginTransactionAsync();

        public void Create(T entity) => DbSet().Add(entity);

        public async Task<K> CreateAsync(T entity)
        {
            await DbSet().AddAsync(entity);
            await SaveChangesAsync();
            return entity.Id;
        }

        public IList<K> CreateList(IEnumerable<T> entities)
        {
            DbSet().AddRange(entities);
            return entities.Select(x => x.Id).ToList();
        }

        public async Task<IList<K>> CreateListAsync(IEnumerable<T> entities)
        {
            await DbSet().AddRangeAsync(entities);
            await SaveChangesAsync();
            return entities.Select(x => x.Id).ToList();
        }

        public void Delete(T entity) => DbSet().Remove(entity);

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(K id)
        {
            var entity = Get(id, true);
            if (entity != null)
            {
                await DeleteAsync(entity);
                return true;
            }
            return false;
        }

        public void DeleteList(IEnumerable<T> entities) => _dbContext.Set<T>().RemoveRange(entities);

        public async Task DeleteListAsync(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            await SaveChangesAsync();
        }

        public async Task EndTransactionAsync()
        {
            await SaveChangesAsync();
            await _dbContext.Database.CommitTransactionAsync();
        }

        public Task RollbackTransactionAsync() => _dbContext.Database.RollbackTransactionAsync();

        public async Task<int> SaveChangesAsync() => await _unitOfWork.CommitAsync();

        public void Update(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Unchanged) return;

            T existedEntity = DbSet().Find(entity.Id);
            _dbContext.Entry(existedEntity).CurrentValues.SetValues(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Unchanged) return;

            T exist = _dbContext.Set<T>().Find(entity.Id);
            _dbContext.Entry(exist).CurrentValues.SetValues(entity);
            await SaveChangesAsync();
        }

        public void UpdateList(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Update(entity);
        }

        public async Task UpdateListAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Update(entity);
            await SaveChangesAsync();
        }

        private DbSet<T> DbSet() => _dbContext.Set<T>();
    }
}

