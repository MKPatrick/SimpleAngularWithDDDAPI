using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Department> Departments { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{

		}
	}
}
