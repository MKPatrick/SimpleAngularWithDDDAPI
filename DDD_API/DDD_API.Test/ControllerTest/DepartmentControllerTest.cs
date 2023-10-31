using DDD_API.Controllers;
using DDD_API.DTO.BaseResponse;
using DDD_API.DTO.Department;
using DDD_API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DDD_API.Test.ControllerTest
{
	[TestClass]
	public class DepartmentControllerTest
	{
		private readonly DepartmentController departmentController;
		private Mock<IDepartmentService> departmentService;
		public DepartmentControllerTest()
		{
			departmentService = new Mock<IDepartmentService>();
			departmentController = new DepartmentController(departmentService.Object);
		}

		[TestMethod]
		public async Task AddDepartment_Successfull()
		{
			AddDepartmentRequest departmentToAdd = new AddDepartmentRequest() { Name = "Test Department" };
			AddDepartmentResponse departmentResponse = new AddDepartmentResponse() { ID = 1, Name = "Test Department" };
			departmentService.Setup(x => x.AddDepartment(departmentToAdd)).ReturnsAsync(departmentResponse);
			var result = await departmentController.AddDepartment(departmentToAdd);
			Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
			var receivedResultOKObject = (OkObjectResult)result.Result;
			Assert.IsInstanceOfType(receivedResultOKObject.Value, typeof(IBaseResponse));
			var baseResponse = (BaseResponse<AddDepartmentResponse>)receivedResultOKObject.Value;
			var expectedResult = new BaseResponse<AddDepartmentResponse>() { Result = departmentResponse };
			Assert.AreEqual(expectedResult.Result, baseResponse.Result);
		}


		[TestMethod]
		public async Task UpdateDepartment_Successfull()
		{
			UpdateDepartmentRequest departmentToUpdate = new UpdateDepartmentRequest() { ID = 1, Name = "Test Department" };
			departmentService.Setup(x => x.UpdateDepartment(departmentToUpdate));
			var result = await departmentController.UpdateDepartment(departmentToUpdate);
			Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
			var receivedResultOKObject = (OkObjectResult)result.Result;
			Assert.IsInstanceOfType(receivedResultOKObject.Value, typeof(IBaseResponse));
		}

		[TestMethod]
		public async Task UpdateDepartment_Unsuccessfull()
		{
			UpdateDepartmentRequest departmentToUpdate = new UpdateDepartmentRequest() { ID = 1, Name = "Test Department" };
			departmentService.Setup(x => x.UpdateDepartment(departmentToUpdate)).ThrowsAsync(new Exception("Wrong Data"));
			var result = await departmentController.UpdateDepartment(departmentToUpdate);
			Assert.IsInstanceOfType(result.Result, typeof(ObjectResult));
			var receivedResultOKObject = (ObjectResult)result.Result;
			Assert.IsInstanceOfType(receivedResultOKObject.Value, typeof(IBaseResponse));
			Assert.AreEqual(500,receivedResultOKObject.StatusCode);
		}


		[TestMethod]
		public async Task AddDepartment_InvalidValidation()
		{
			AddDepartmentRequest departmentToAdd = new AddDepartmentRequest() { Name = null };
			AddDepartmentResponse departmentResponse = new AddDepartmentResponse() { ID = 1, Name = "Test Department" };
			departmentService.Setup(x => x.AddDepartment(departmentToAdd)).ReturnsAsync(departmentResponse);
			var result = await departmentController.AddDepartment(departmentToAdd);
			Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
			var receivedResultOKObject = (OkObjectResult)result.Result;
			Assert.IsInstanceOfType(receivedResultOKObject.Value, typeof(IBaseResponse));
			var baseResponse = (BaseResponse<AddDepartmentResponse>)receivedResultOKObject.Value;
			var expectedResult = new BaseResponse<AddDepartmentResponse>() { Result = departmentResponse };
			Assert.AreEqual(expectedResult.Result, baseResponse.Result);
		}


		[TestMethod]
		public async Task ReturnDepartments()
		{
			List<GetDepartmentResponse> getDepartmentResponses = new List<GetDepartmentResponse>() { new GetDepartmentResponse { ID = 1 }, new GetDepartmentResponse { ID = 2 } };
			departmentService.Setup(x => x.GetAllDepartments()).ReturnsAsync(getDepartmentResponses);
			var result = await departmentController.GetAllDepartments();
			Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
			var receivedResultOKObject = (OkObjectResult)result.Result;
			Assert.IsInstanceOfType(receivedResultOKObject.Value, typeof(IBaseResponse));
			var baseResponse = (BaseResponse<IEnumerable<GetDepartmentResponse>>)receivedResultOKObject.Value;
			var expectedResult = new BaseResponse<IEnumerable<GetDepartmentResponse>>() { Result = getDepartmentResponses };
			Assert.AreEqual(expectedResult.Result, baseResponse.Result);
		}


		[TestMethod]
		public async Task ReturnDepartment_When_ID_Matches()
		{
			GetDepartmentResponse getDepartmentResponse = new GetDepartmentResponse();
			getDepartmentResponse.ID = 1;
			departmentService.Setup(x => x.GetDepartmentById(1)).ReturnsAsync(getDepartmentResponse);
			var result = await departmentController.GetDepartmentById(1);
			Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
			var receivedResultOKObject = (OkObjectResult)result.Result;
			Assert.IsInstanceOfType(receivedResultOKObject.Value, typeof(IBaseResponse));
			var baseResponse = (BaseResponse<GetDepartmentResponse>)receivedResultOKObject.Value;
			var expectedResult = new BaseResponse<GetDepartmentResponse>() { Result = getDepartmentResponse };
			Assert.AreEqual(expectedResult.Result, baseResponse.Result);
		}

		[TestMethod]
		public async Task DeleteDepartment_Success()
		{

			departmentService.Setup(x => x.DeleteDepartmentByID(1));
			var result = await departmentController.DeleteDepartmentByID(1);
			Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
			var receivedResultOKObject = (OkObjectResult)result.Result;
			Assert.IsInstanceOfType(receivedResultOKObject.Value, typeof(IBaseResponse));
		}

		[TestMethod]
		public async Task DeleteDepartment_Invalid()
		{

			departmentService.Setup(x => x.DeleteDepartmentByID(2)).ThrowsAsync(new Exception("User does not exist"));
			var result = await departmentController.DeleteDepartmentByID(2);
			Assert.IsInstanceOfType(result.Result, typeof(ObjectResult));
			var receivedErrorObject = (ObjectResult)result.Result;
			Assert.AreEqual(500, receivedErrorObject.StatusCode);
		}



		[TestMethod]
		public async Task ReturnNotFound_When_ID_DoesMatches()
		{
			GetDepartmentResponse getDepartmentResponse = new GetDepartmentResponse();
			getDepartmentResponse.ID = 1;
			departmentService.Setup(x => x.GetDepartmentById(1)).ReturnsAsync(getDepartmentResponse);
			var result = await departmentController.GetDepartmentById(0);
			Assert.IsInstanceOfType(result.Result, typeof(NotFoundObjectResult));
			var receivedErrorObject = (NotFoundObjectResult)result.Result;
			Assert.IsInstanceOfType(receivedErrorObject.Value, typeof(IBaseResponse));
		}

	}
}