using Domain.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
	{
		public DepartmentRepository(DatabaseContext context) : base(context)
		{
		}


	}
}
