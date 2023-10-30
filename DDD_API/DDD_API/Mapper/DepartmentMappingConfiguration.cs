using AutoMapper;
using DDD_API.DTO.Department;
using DDD_API.DTO.Employee;
using Domain.Entities;

namespace DDD_API.Mapper
{
	public class DepartmentMappingConfiguration : Profile
	{
		public DepartmentMappingConfiguration()
		{
			CreateMap<Department, AddDepartmentRequest>();
			CreateMap<AddDepartmentRequest, Department>();
			CreateMap<UpdateDepartmentRequest, Department>();
			CreateMap<Department, GetDepartmentResponse>();
		}
	}
}
