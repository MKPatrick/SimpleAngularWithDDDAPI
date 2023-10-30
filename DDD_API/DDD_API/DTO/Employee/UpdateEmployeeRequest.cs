namespace DDD_API.DTO.Employee
{
	public class UpdateEmployeeRequest
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Title { get; set; }
		public string Address { get; set; }

		public int? DepartmentID { get; set; }
	}
}
