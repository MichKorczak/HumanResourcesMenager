using HumanResourcesManager.Core.Entities;

namespace HumanResourcesManager.Infrastructure.Tests.Helpers
{
	public static class HelperEmployee
	{
		public static bool EqualEmployees(this Employee firstEmployee, Employee secondEmployee)
		{
			if (firstEmployee.FirstName != secondEmployee.FirstName)
			{
				return false;
			}
			if (firstEmployee.LastName != secondEmployee.LastName)
			{
				return false;
			}
			if (firstEmployee.Address != secondEmployee.Address)
			{
				return false;
			}
			if (firstEmployee.DateOfBirth != secondEmployee.DateOfBirth)
			{
				return false;
			}
			return true;
		}
	}
}