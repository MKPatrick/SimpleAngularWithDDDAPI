using DDD_API.DTO.BaseResponse;
using DDD_API.DTO.Department;
using DDD_API.DTO.Employee;
using DDD_API.Factories;
using DDD_API.Helpers;
using DDD_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{
		private readonly IDepartmentService departmentService;

		public DepartmentController(IDepartmentService departmentService)
		{
			this.departmentService = departmentService;
		}

		[HttpGet(nameof(GetAllDepartments))]
		public async Task<ActionResult<IBaseResponse>> GetAllDepartments()
		{
			try
			{
				var allDepartments = await departmentService.GetAllDepartments();
				var response = BaseResponseFactory.Create(allDepartments);
				response.Message = "Successfully feteched all departments";
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


		[HttpPut(nameof(UpdateDepartment))]
		public async Task<ActionResult<IBaseResponse>> UpdateDepartment([FromBody] UpdateDepartmentRequest updateDepartmentRequest)
		{
			try
			{
				await departmentService.UpdateDepartment(updateDepartmentRequest);
				var response = BaseResponseFactory.Create();
				response.Message = "Successfully updated all departments";
				return Ok(response);

			}
			catch (Exception ex)
			{
				var responseError = BaseResponseFactory.Create();
				responseError.Message = "Error by Updating department";
				Logger.Error(ex);
				return BadRequest(responseError);
			}
		}

		[HttpPost(nameof(AddDepartment))]
		public async Task<ActionResult<IBaseResponse>> AddDepartment([FromBody] AddDepartmentRequest addDepartment)
		{
			try
			{
				await departmentService.AddDepartment(addDepartment);
				var response = BaseResponseFactory.Create();
				response.Message = "Add department successfull";

				return Ok(response);

			}
			catch (Exception ex)
			{
				var responseError = BaseResponseFactory.Create();
				responseError.Message = "Error by Add department";
				Logger.Error(ex);
				return BadRequest(responseError);
			}
		}


		[HttpGet(nameof(GetDepartmentById))]
		public async Task<ActionResult<IBaseResponse>> GetDepartmentById(int userID)
		{
			try
			{
				var entity = await departmentService.GetDepartmentById(userID);
				var response = BaseResponseFactory.Create(entity);
				response.Message = "Get Department successfull";
				return Ok(response);

			}
			catch (Exception ex)
			{
				var responseError = BaseResponseFactory.Create();
				responseError.Message = "Error by Getting Department";
				Logger.Error(ex);
				return BadRequest(responseError);
			}
		}


		[HttpDelete(nameof(DeleteDepartmentByID))]
		public async Task<ActionResult<IBaseResponse>> DeleteDepartmentByID(int departmentID)
		{
			try
			{
				await departmentService.DeleteDepartmentByID(departmentID);
				var response = BaseResponseFactory.Create();
				response.Message = "Department deleted successfully";
				return Ok(response);

			}
			catch (Exception ex)
			{
				var responseError = BaseResponseFactory.Create();
				responseError.Message = "Error by deleting Department";
				Logger.Error(ex);
				return BadRequest(responseError);
			}
		}
	}
}
