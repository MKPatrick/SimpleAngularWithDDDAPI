using AutoMapper;
using DDD_API.DTO.Employee;
using Domain.Entities;

namespace DDD_API.Mapper
{
	public class EmployeeMappingConfiguration : Profile
	{
		public EmployeeMappingConfiguration()
		{
			CreateMap<Employee, AddEmployeeRequest>();
			CreateMap<AddEmployeeRequest, Employee>();
			CreateMap<UpdateEmployeeRequest, Employee>();
			CreateMap<Employee, GetEmployeeResponse>();
		}
	}
}
