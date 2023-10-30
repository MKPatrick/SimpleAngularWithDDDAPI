using System.ComponentModel.DataAnnotations;

namespace DDD_API.DTO.Department
{
	public class AddDepartmentRequest
	{
		[Required]
		[MinLength(1)]
		[MaxLength(20)]
		public string Name { get; set; }

	}
}
