namespace HumanResourcesManager.Core.Entities
{
	public class EmployeeJobPosition : Entity
	{
		protected EmployeeJobPosition() { }

		public EmployeeJobPosition(JobPosition position, Employee employee)
		{
			Position = position;
			Employee = employee;
		}

		public JobPosition Position { get; private set; }

		public Employee Employee { get; private set; }

		public bool IsActive { get; set; } = true;
	}
}