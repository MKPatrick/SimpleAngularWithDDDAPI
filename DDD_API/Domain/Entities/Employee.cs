namespace Domain.Entities
{
	public class Employee
	{
		public int ID { get; set; }
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Title { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;

		public int? DepartmentID { get; set; }
		public Department? Department { get; set; }
	}
}
