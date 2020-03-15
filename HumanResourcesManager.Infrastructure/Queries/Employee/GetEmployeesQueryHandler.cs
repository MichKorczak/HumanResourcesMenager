using AutoMapper;
using HumanResourcesManager.Core.Dto;
using HumanResourcesManager.Infrastructure.Services.Abstract;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HumanResourcesManager.Infrastructure.Queries.Employee
{
	public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQueryModel, IList<EmployeeDto>>
	{
		private readonly IGetEmployeesService service;
		private readonly IMapper mapper;

		public GetEmployeesQueryHandler(IGetEmployeesService service, IMapper mapper)
		{
			this.service = service;
			this.mapper = mapper;
		}

		public async Task<IList<EmployeeDto>> Handle(GetEmployeesQueryModel request, CancellationToken cancellationToken)
		{
			var employeeList = await service.GetEmployesAsync();
			var employeeDTO = mapper.Map<IList<EmployeeDto>>(employeeList);
			return employeeDTO;
		}
	}
}
