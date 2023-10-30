using Domain.Contracts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UOW
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly DatabaseContext dbContext; 

		public UnitOfWork(DatabaseContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task<int> SaveChangesAsync()
		{
			return await dbContext.SaveChangesAsync();
		}
	}
}
