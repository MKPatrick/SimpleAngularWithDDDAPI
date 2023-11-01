using AutoFixture;
using DDD_API.DTO.Employee;
using DDD_API.Validation;
using FluentValidation.TestHelper;

namespace DDD_API.Test.ValidationTest
{

    [TestClass]
    public class AddEmployeeValidationTest
    {
        private Fixture fixture;
        public AddEmployeeValidationTest()
        {
            fixture = new Fixture();
        }

        [TestMethod]
        public void ShouldHaveError_WhenEverythingIsEmpty()
        {
            var validator = new AddEmployeeValidation();
            var model = new AddEmployeeRequest { };
            var result = validator.TestValidate(model);
            result.ShouldHaveAnyValidationError();
        }

        [TestMethod]
        [DataRow("Max", "Mustermann", "Example street", "Dr.")]
        [DataRow("P", "Meier", " street", "")]
        public void ShouldHaveNoError(string firstname, string lastname, string address, string title)
        {
            var validator = new AddEmployeeValidation();
            var model = fixture.Build<AddEmployeeRequest>().With(x => x.FirstName, firstname).With(x => x.LastName, lastname).With(x => x.Address, address).With(x => x.Title, title).Create();
            var result = validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void FirstName_ShouldHaveError_WhenEmpty()
        {
            var validator = new AddEmployeeValidation();
            var model = fixture.Build<AddEmployeeRequest>().Without(x => x.FirstName).Create();
            var result = validator.TestValidate(model);
            result.ShouldHaveAnyValidationError();
        }


        [TestMethod]
        public void LastName_ShouldHaveError_WhenEmpty()
        {
            var validator = new AddEmployeeValidation();
            var model = fixture.Build<AddEmployeeRequest>().Without(x => x.LastName).Create();
            var result = validator.TestValidate(model);
            result.ShouldHaveAnyValidationError();
        }


        [TestMethod]
        public void Address_ShouldHaveError_Empty()
        {
            var validator = new AddEmployeeValidation();
            var model = fixture.Build<AddEmployeeRequest>().Without(x => x.Address).Create();
            var result = validator.TestValidate(model);
            result.ShouldHaveAnyValidationError();
        }


    }
}
