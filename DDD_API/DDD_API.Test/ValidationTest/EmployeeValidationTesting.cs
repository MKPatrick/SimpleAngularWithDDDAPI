using DDD_API.DTO.Employee;
using DDD_API.Validation;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_API.Test.ValidationTest
{
	[TestClass]
	public class AddEmployeeValidationTesting
	{
		[TestMethod]
		public void ShouldHaveError_WhenEverythingIsEmpty()
		{
			var validator = new AddEmployeeValidation();
			var model = new AddEmployeeRequest { };
			var result = validator.TestValidate(model);
			result.ShouldHaveAnyValidationError();
		}

		[TestMethod]
		public void ShouldHaveNoError()
		{
			var validator = new AddEmployeeValidation();
			var model = new AddEmployeeRequest {FirstName="123", LastName="lastname", Address="Address", Title="Dr." };
			var result = validator.TestValidate(model);
			result.ShouldNotHaveAnyValidationErrors();
		}

		[TestMethod]
		public void FirstName_ShouldHaveError_WhenNameIsEmpy()
		{
			var validator = new AddEmployeeValidation();
			var model = new AddEmployeeRequest { FirstName = string.Empty, LastName = "lastname", Address = "Address", Title = "Dr." };
			var result = validator.TestValidate(model);
			result.ShouldHaveAnyValidationError();
		}


	}
}
