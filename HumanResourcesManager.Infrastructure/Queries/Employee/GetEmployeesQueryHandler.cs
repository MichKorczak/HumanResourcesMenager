using HumanResourcesManager.Core.Dto;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HumanResourcesManager.Core.Repositories.Abstract;
using HumanResourcesManager.Infrastructure.Interfaces;

namespace HumanResourcesManager.Infrastructure.Queries.Employee
{
	public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQueryModel, IEnumerable<EmployeeDto>>
	{
		private readonly IEmployeesRepository repository;
		private readonly IMapper mapper;

		public GetEmployeesQueryHandler(IEmployeesRepository repository, IMapper mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeesQueryModel request, CancellationToken cancellationToken)
		{
			var employeeList = await repository.GetEmployesAsync();
			var employeeDto = mapper.MapCollection<Core.Entities.Employee, EmployeeDto>(employeeList);
			return employeeDto;
		}
	}
}
