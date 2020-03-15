using AutoMapper;
using HumanResourcesManager.Core.DbDomain.Abstract;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Infrastructure.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanResourcesManager.Infrastructure.Services.Implementations
{
	public class GetEmployeesService : IGetEmployeesService
	{
		private readonly IUserContext context;

		public GetEmployeesService(IUserContext context, IMapper mapper)
		{
			this.context = context;
		}

		public async Task<IList<Employee>> GetEmployesAsync() => await context.Employes.ToListAsync();
	}
}
