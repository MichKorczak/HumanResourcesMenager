using HumanResourcesMenager.Core.DTO;
using HumanResourcesMenager.Infrastructure.Queries.Models;
using HumanResourcesMenager.Infrastructure.Services.Abstract;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HumanResourcesMenager.Infrastructure.Queries.Handlers
{
	public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQueryModel, IList<EmployeDTO>>
	{
		private readonly IGetEmployeesService service;

		public GetEmployeesQueryHandler(IGetEmployeesService service)
		{
			this.service = service;
		}

		public async Task<IList<EmployeDTO>> Handle(GetEmployeesQueryModel request, CancellationToken cancellationToken) => await service.GetEmployesAsync();
	}
}
