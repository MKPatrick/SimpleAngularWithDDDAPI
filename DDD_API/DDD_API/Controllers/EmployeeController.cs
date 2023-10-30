using DDD_API.DTO.BaseResponse;
using DDD_API.DTO.Employee;
using DDD_API.Factories;
using DDD_API.Helpers;
using DDD_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DDD_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeService employeeService;

		public EmployeeController(IEmployeeService employeeService)
		{
			this.employeeService = employeeService;
		}

		[HttpGet(nameof(GetEmployees))]
		public async Task<ActionResult<IBaseResponse>> GetEmployees()
		{
			try
			{
				var allemploees = await employeeService.GetAllEmployees();
				var response = BaseResponseFactory.Create(allemploees);
				response.Message = "Successfully feteched all employees";
				return Ok(response);

			}
			catch (Exception ex)
			{
				var responseError = BaseResponseFactory.Create();
				responseError.Message = "Error by Fetching";
				Logger.Error(ex);
				return BadRequest(responseError);
			}
		}


		[HttpPut(nameof(UpdateEmployee))]
		public async Task<ActionResult<IBaseResponse>> UpdateEmployee([FromBody] UpdateEmployeeRequest updateEmployeeRequest)
		{
			try
			{
				await employeeService.UpdateEmployee(updateEmployeeRequest);
				var response = BaseResponseFactory.Create();
				response.Message = "Successfully feteched all employees";
				return Ok(response);

			}
			catch (Exception ex)
			{
				var responseError = BaseResponseFactory.Create();
				responseError.Message = "Error by Updating Employee";
				Logger.Error(ex);
				return BadRequest(responseError);
			}
		}

		[HttpPost(nameof(AddEmployee))]
		public async Task<ActionResult<IBaseResponse>> AddEmployee([FromBody] AddEmployeeRequest addEmployeeRequest)
		{
			try
			{
				await employeeService.AddEmployee(addEmployeeRequest);
				var response = BaseResponseFactory.Create();
				response.Message = "Add employee successfull";
	
				return Ok(response);

			}
			catch (Exception ex)
			{
				var responseError = BaseResponseFactory.Create();
				responseError.Message = "Error by Updating Employee";
				Logger.Error(ex);
				return BadRequest(responseError);
			}
		}


		[HttpGet(nameof(GetEmployeeByID))]
		public async Task<ActionResult<IBaseResponse>> GetEmployeeByID(int id)
		{
			try
			{
				var entity = await employeeService.GetEmployeeByID(id);
				var response = BaseResponseFactory.Create(entity);
				response.Message = "Get employee successfull";
				return Ok(response);

			}
			catch (Exception ex)
			{
				var responseError = BaseResponseFactory.Create();
				responseError.Message = "Error by Getting Employee";
				Logger.Error(ex);
				return BadRequest(responseError);
			}
		}


		[HttpDelete(nameof(DeleteEmployeeByID))]
		public async Task<ActionResult<IBaseResponse>> DeleteEmployeeByID(int id)
		{
			try
			{
				await employeeService.DeleteEmployeeByID(id);
				var response = BaseResponseFactory.Create();
				response.Message = "Employee deleted successfully";
				return Ok(response);

			}
			catch (Exception ex)
			{
				var responseError = BaseResponseFactory.Create();
				responseError.Message = "Error by deleting Employee";
				Logger.Error(ex);
				return BadRequest(responseError);
			}
		}
	}
}
