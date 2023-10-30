using Domain.Contracts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
	{
		private DatabaseContext context;
		private DbSet<TEntity> dbSet;

		public BaseRepository(DatabaseContext context)
		{
			this.context = context ?? throw new ArgumentNullException(nameof(context));
			dbSet = context.Set<TEntity>();
		}

		public virtual async Task<TEntity> GetByIdAsync(int id)
		{
			return await dbSet.FindAsync(id);
		}

		public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await dbSet.ToListAsync();
		}

		public virtual async Task<TEntity> AddAsync(TEntity entity)
		{
			var value = await dbSet.AddAsync(entity);
			return value.Entity;
		}

		public virtual async Task UpdateAsync(TEntity entity)
		{
			dbSet.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;

		}

		public virtual async Task DeleteAsync(int id)
		{
			var entity = await GetByIdAsync(id);
			if (entity != null)
				dbSet.Remove(entity);

		}

	}
}
