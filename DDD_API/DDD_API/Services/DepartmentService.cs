using AutoMapper;
using DDD_API.DTO.Department;
using Domain.Contracts;
using Domain.Entities;

namespace DDD_API.Services
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IDepartmentRepository departmentRepository;
		private readonly IMapper mapper;

		public DepartmentService(IUnitOfWork unitOfWork, IDepartmentRepository departmentRepository, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.departmentRepository = departmentRepository;
			this.mapper = mapper;
		}


		public async Task<IEnumerable<GetDepartmentResponse>> GetAllDepartments()
		{
			var entities = await departmentRepository.GetAllAsync();
			var result = entities.Select(x => mapper.Map<GetDepartmentResponse>(x)).ToList();
			return result;
		}

		public async Task<GetDepartmentResponse> GetDepartmentById(int departmentID)
		{
			var entities = await departmentRepository.GetByIdAsync(departmentID);
			var result = mapper.Map<GetDepartmentResponse>(entities);
			return result;
		}

		public async Task<AddDepartmentResponse> AddDepartment(AddDepartmentRequest addEmployeeRequest)
		{
			var entity = mapper.Map<Department>(addEmployeeRequest);
			await departmentRepository.AddAsync(entity);
			await unitOfWork.SaveChangesAsync();
			var result = mapper.Map<Department, AddDepartmentResponse>(entity);
			return result;
		}

		public async Task UpdateDepartment(UpdateDepartmentRequest updateDepartment)
		{
			var entity = mapper.Map<Department>(updateDepartment);
			await departmentRepository.UpdateAsync(entity);
			await unitOfWork.SaveChangesAsync();
		}


		public async Task DeleteDepartmentByID(int ID)
		{
			await departmentRepository.DeleteAsync(ID);
			await unitOfWork.SaveChangesAsync();
		}

	}
}
