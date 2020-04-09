using System;
using System.Collections.Generic;

namespace HumanResourcesManager.Core.Entities
{
	public class JobPosition : Entity
	{
		public JobPosition(string positionName)
		{
			PositionName = positionName;
		}

		public string PositionName { get; private set; }

		public List<EmployeeJobPosition> EmployeeJobPositions { get; set; }
	}
}
