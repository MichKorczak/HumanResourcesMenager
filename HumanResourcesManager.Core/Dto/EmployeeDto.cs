using HumanResourcesManager.Core.Enums;
using System;

namespace HumanResourcesManager.Core.Dto
{
	public class EmployeeDto
	{
		public string FirstName { get; set; }

		public string LasttName { get; set; }

		public JobPositions Position { get; set; }

		public int RoomNumber { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string Address { get; set; }
	}
}
