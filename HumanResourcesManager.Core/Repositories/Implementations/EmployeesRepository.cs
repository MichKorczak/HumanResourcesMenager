using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HumanResourcesManager.Core.DbDomain;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Core.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesManager.Core.Repositories.Implementations
{
	public class EmployeesRepository : Repository, IEmployeesRepository
	{
		private readonly HumanResourceContext context;

		public EmployeesRepository(HumanResourceContext context) 
			: base(context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<Employee>> GetEmployeesAsync() => await context.Employees.ToArrayAsync();

		public async Task AddEmployeeAsync(Employee employee) => await context.Employees.AddAsync(employee);

		public async Task<Employee> GetEmployeeAsync(Guid employeeId) => await context.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);
	}
}
