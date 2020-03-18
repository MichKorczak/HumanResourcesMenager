using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HumanResourcesManager.Core.DbDomain.Abstract;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesManager.Infrastructure.Repositories.Implementations
{
	public class GetEmployeesRepository : IGetEmployeesRepository
	{
		private readonly IHumanResourceContext context;

		public GetEmployeesRepository(IHumanResourceContext context, IMapper mapper)
		{
			this.context = context;
		}

		public async Task<IList<Employee>> GetEmployesAsync() => await context.Employes.ToListAsync();
	}
}
