using Domain.Contracts;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
	public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(DatabaseContext context) : base(context)
		{
		}
	}
}
