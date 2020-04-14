using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HumanResourcesManager.Core.Entities;

namespace HumanResourcesManager.Core.Repositories.Abstract
{
	public interface IEmployeesRepository : IRepository
	{
		Task<IEnumerable<Employee>> GetEmployeesAsync();

		Task AddEmployeeAsync(Employee employee);

		Task<Employee> GetEmployeeAsync(Guid employeeId);
	}
}
