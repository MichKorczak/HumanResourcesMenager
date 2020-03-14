using HumanResourcesMenager.Core.Enums;
using System;

namespace HumanResourcesMenager.Core.DTO
{
	public class EmployeDTO
	{
		public string FirstName { get; set; }

		public string LasttName { get; set; }

		public JobPositions Position { get; set; }

		public int RoomNumber { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string Address { get; set; }
	}
}
