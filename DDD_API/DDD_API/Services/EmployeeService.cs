using AutoMapper;
using DDD_API.DTO.Employee;
using Domain.Contracts;
using Domain.Entities;

namespace DDD_API.Services
{
	public class EmployeeService : IEmployeeService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IEmployeeRepository employeeRepository;
		private readonly IMapper mapper;

		public EmployeeService(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.employeeRepository = employeeRepository;
			this.mapper = mapper;
		}


		public async Task<IEnumerable<GetEmployeeResponse>> GetAllEmployees()
		{
			var entities = await employeeRepository.GetAllAsync();
			var result = entities.Select(x => mapper.Map<GetEmployeeResponse>(x)).ToList();
			return result;
		}

		public async Task<GetEmployeeResponse> GetEmployeeByID(int employeeID)
		{
			var entities = await employeeRepository.GetByIdAsync(employeeID);
			var result = mapper.Map<GetEmployeeResponse>(entities);
			return result;
		}

		public async Task AddEmployee(AddEmployeeRequest addEmployeeRequest)
		{
			var entity = mapper.Map<Employee>(addEmployeeRequest);
			await employeeRepository.AddAsync(entity);
			await unitOfWork.SaveChangesAsync();
		}

		public async Task UpdateEmployee(UpdateEmployeeRequest addEmployeeRequest)
		{
			var entity = mapper.Map<Employee>(addEmployeeRequest);
			await employeeRepository.UpdateAsync(entity);
			await unitOfWork.SaveChangesAsync();
		}



		public async Task DeleteEmployeeByID(int ID)
		{
			await employeeRepository.DeleteAsync(ID);
			await unitOfWork.SaveChangesAsync();
		}

	}
}
