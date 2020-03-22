using HumanResourcesManager.Core.Dto;
using MediatR;
using System.Collections.Generic;

namespace HumanResourcesManager.Infrastructure.Queries.Employee
{
	public class GetEmployeesQueryModel : IRequest<IEnumerable<EmployeeDto>>
	{
	}
}
