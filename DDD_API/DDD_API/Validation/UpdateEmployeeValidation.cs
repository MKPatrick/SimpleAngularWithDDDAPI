using DDD_API.DTO.Employee;
using FluentValidation;

namespace DDD_API.Validation
{
	public class UpdateEmployeeValidation : AbstractValidator<UpdateEmployeeRequest>
	{
        public UpdateEmployeeValidation()
        {
			RuleFor(employee => employee.FirstName).NotEmpty().WithMessage("First-Name cannot be empty").Length(1, 50).WithMessage("The firstname must be between 1 and 50 characters");
			RuleFor(employee => employee.LastName).NotEmpty().WithMessage("Last-Name cannot be empty").Length(1, 50).WithMessage("The lastname must be between 1 and 50 characters");
			RuleFor(employee => employee.Address).NotEmpty().WithMessage("Address cannot be empty").Length(1, 100).WithMessage("The title must be between 1 and 100 characters");

		}

	}
}
