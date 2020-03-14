using AutoMapper;
using HumanResourcesMenager.Core.DBDomain.Abstract;
using HumanResourcesMenager.Core.DTO;
using HumanResourcesMenager.Infrastructure.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanResourcesMenager.Infrastructure.Services.Implementations
{
	public class GetEmployeesService : IGetEmployeesService
	{
		private readonly IUserContext context;
		private readonly IMapper mapper;

		public GetEmployeesService(IUserContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<IList<EmployeDTO>> GetEmployesAsync() => mapper.Map<IList<EmployeDTO>>(await context.Employes.ToListAsync());
	}
}
