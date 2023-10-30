using DDD_API.DTO.Employee;

namespace DDD_API.Services
{
	public interface IEmployeeService
	{
		Task AddEmployee(AddEmployeeRequest addEmployeeRequest);
		Task DeleteEmployeeByID(int ID);
		Task<IEnumerable<GetEmployeeResponse>> GetAllEmployees();
		Task<GetEmployeeResponse> GetEmployeeByID(int employeeID);
		Task UpdateEmployee(UpdateEmployeeRequest addEmployeeRequest);
	}
}