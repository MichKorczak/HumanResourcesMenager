﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HumanResourcesManager.Core.Entities;

namespace HumanResourcesManager.Core.Repositories.Abstract
{
	public interface IEmployeesRepository : IRepository
	{
		Task<IEnumerable<Employee>> GetEmployesAsync();

		Task AddEmployeeAsync(Employee employee);
	}
}
