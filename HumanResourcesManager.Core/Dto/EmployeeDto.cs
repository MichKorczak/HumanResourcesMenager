using System;

namespace HumanResourcesManager.Core.Dto
{
	public class EmployeeDto
	{
		public Guid Id { get; set; }		

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string MainRole { get; set; }

		public int RoomNumber { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string Address { get; set; }
	}
}
