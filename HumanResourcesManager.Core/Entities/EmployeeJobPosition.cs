namespace HumanResourcesManager.Core.Entities
{
	public class EmployeeJobPosition : Entity
	{
		public EmployeeJobPosition(JobPosition position, Employee employee)
		{
			Position = position;
			Employee = employee;
		}

		protected EmployeeJobPosition()
		{
		}

		public JobPosition Position { get; private set; }

		public Employee Employee { get; private set; }

		public bool IsActive { get; set; } = true;
	}
}