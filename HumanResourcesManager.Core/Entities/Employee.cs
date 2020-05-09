using System;
using System.Collections.Generic;

namespace HumanResourcesManager.Core.Entities
{
	public class Employee : Entity
	{
		public Employee(string firstName, string lastName, DateTime dateOfBirth, string address)
		{
			FirstName = firstName;
			LastName = lastName;
			DateOfBirth = dateOfBirth;
			Address = address;
			Positions = new List<EmployeeJobPosition>();
		}

		public string FirstName { get; private set; }

		public string LastName { get; private set; }

		public List<EmployeeJobPosition> Positions { get; set; }

		public DateTime DateOfBirth { get; private set; }

		public string Address { get; private set; }

		public string MainRole { get; set; }

		public int RoomNumber { get; set; }

		public Employee ManagerEmployee { get; set; }

		public Guid ManagerId { get; set; }
	}
}
