namespace Domain.Contracts
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		Task<TEntity> AddAsync(TEntity entity);
		Task DeleteAsync(int id);
		Task<IEnumerable<TEntity>> GetAllAsync();
		Task<TEntity> GetByIdAsync(int id);
		Task UpdateAsync(TEntity entity);

	}
}
