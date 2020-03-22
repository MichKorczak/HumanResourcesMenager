using System.Collections.Generic;
using System.Threading.Tasks;
using HumanResourcesManager.Core.DbDomain.Abstract;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Core.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesManager.Core.Repositories.Implementations
{
	public class EmployeesRepository : IEmployeesRepository
	{
		private readonly IHumanResourceContext context;

		public EmployeesRepository(IHumanResourceContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<Employee>> GetEmployesAsync() => await context.Employees.ToArrayAsync();
	}
}
