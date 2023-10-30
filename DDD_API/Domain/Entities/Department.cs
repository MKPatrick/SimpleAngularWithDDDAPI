﻿namespace Domain.Entities
{
	public class Department
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public List<Employee>? Employees { get; set; }
	}
}
