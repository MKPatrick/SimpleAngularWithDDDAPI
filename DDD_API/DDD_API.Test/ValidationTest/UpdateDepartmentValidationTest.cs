using AutoFixture;
using DDD_API.DTO.Department;
using System.ComponentModel.DataAnnotations;

namespace DDD_API.Test.ValidationTest
{
	[TestClass]
	public class UpdateDepartmentValidationTest
	{
		private Fixture fixture;

		public UpdateDepartmentValidationTest()
		{
			fixture = new Fixture();
		}

		[TestMethod]
		public void ShouldHaveError_WhenEverythingIsEmpty()
		{
			var model = new UpdateDepartmentRequest { };
			ValidationContext validation = new ValidationContext(model);
			var validationResults = new List<ValidationResult>();
			bool isValid = Validator.TryValidateObject(model, validation, validationResults);
			Assert.IsFalse(isValid);
		}

		[TestMethod]
		public void ShouldHaveNoError_WhenEverythingIsFilledOut()
		{
			var model = fixture.Create<UpdateDepartmentRequest>();
			ValidationContext validation = new ValidationContext(model);
			var validationResults = new List<ValidationResult>();
			bool isValid = Validator.TryValidateObject(model, validation, validationResults);
			Assert.IsTrue(isValid);
		}
	}
}
