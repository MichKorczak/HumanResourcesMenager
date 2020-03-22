using HumanResourcesManager.Core.Enums;
using System;
using HumanResourcesManager.Core.Entities;

namespace HumanResourcesManager.Core.Dto
{
	public class EmployeeDto : Entity
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public JobPositions Position { get; set; }

		public int RoomNumber { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string Address { get; set; }
	}
}
