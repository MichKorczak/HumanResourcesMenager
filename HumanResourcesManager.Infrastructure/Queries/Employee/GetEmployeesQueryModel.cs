using System.Collections.Generic;
using HumanResourcesManager.Core.Dto;
using MediatR;

namespace HumanResourcesManager.Infrastructure.Queries.Employee
{
	public class GetEmployeesQueryModel : IRequest<IEnumerable<EmployeeDto>>
	{
	}
}
