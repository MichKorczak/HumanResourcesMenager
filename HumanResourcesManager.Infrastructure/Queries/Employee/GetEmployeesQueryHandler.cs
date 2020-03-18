using AutoMapper;
using HumanResourcesManager.Core.Dto;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HumanResourcesManager.Infrastructure.Repositories.Abstract;

namespace HumanResourcesManager.Infrastructure.Queries.Employee
{
	public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQueryModel, IList<EmployeeDto>>
	{
		private readonly IGetEmployeesRepository service;
		private readonly IMapper mapper;

		public GetEmployeesQueryHandler(IGetEmployeesRepository service, IMapper mapper)
		{
			this.service = service;
			this.mapper = mapper;
		}

		public async Task<IList<EmployeeDto>> Handle(GetEmployeesQueryModel request, CancellationToken cancellationToken)
		{
			var employeeList = await service.GetEmployesAsync();
			var employeeDto = mapper.Map<IList<EmployeeDto>>(employeeList);
			return employeeDto;
		}
	}
}
