using AutoFixture;
using DDD_API.DTO.Department;
using System.ComponentModel.DataAnnotations;

namespace DDD_API.Test.ValidationTest
{
    [TestClass]
    public class AddDepartmentValidationTest
    {
        private Fixture fixture;

        public AddDepartmentValidationTest()
        {
            fixture = new Fixture();

        }
        [TestMethod]
        public void ShouldHaveError_WhenEverythingIsEmpty()
        {
            var department = fixture.Build<AddDepartmentRequest>().Without(x => x.Name).Create();
            ValidationContext validation = new ValidationContext(department);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(department, validation, validationResults, true);
            Assert.IsFalse(isValid);
        }


        [TestMethod]
        public void ShouldHaveNoError_WhenEverythingIsFilledOut()
        {
            var department = fixture.Build<AddDepartmentRequest>().Create();
            ValidationContext validation = new ValidationContext(department);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(department, validation, validationResults, true);
            Assert.IsTrue(isValid);
        }
    }
}
