using DDD_API.DTO.Department;

namespace DDD_API.Services
{
	public interface IDepartmentService
	{
		Task<AddDepartmentResponse> AddDepartment(AddDepartmentRequest addEmployeeRequest);
		Task DeleteDepartmentByID(int ID);
		Task<IEnumerable<GetDepartmentResponse>> GetAllDepartments();
		Task<GetDepartmentResponse> GetDepartmentById(int employeeID);
		Task UpdateDepartment(UpdateDepartmentRequest updateDepartment);
	}
}