

namespace DDD_API.DTO.Employee
{
	public class AddEmployeeRequest
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Title { get; set; }
		public string Address { get; set; }
		public int? DepartmentID { get; set; }
	}
}
