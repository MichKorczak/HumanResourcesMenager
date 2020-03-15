using HumanResourcesManager.Core.Abstract;
using HumanResourcesManager.Core.Enums;
using System;

namespace HumanResourcesManager.Core.Entities
{
	public class Employee : Entity
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public JobPositions Position { get; set; }

		public int RoomNumber { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string Address { get; set; }
	}
}
