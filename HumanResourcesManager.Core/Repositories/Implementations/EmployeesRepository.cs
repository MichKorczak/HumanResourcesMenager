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

		public async Task<IEnumerable<Employee>> GetEmployesAsync() => await context.Employees.ToArrayAsync();

		public async Task AddEmployeeAsync(Employee employee) => await context.Employees.AddAsync(employee);
	}
}
