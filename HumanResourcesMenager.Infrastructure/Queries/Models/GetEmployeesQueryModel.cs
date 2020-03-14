using HumanResourcesMenager.Core.DTO;
using MediatR;
using System.Collections.Generic;

namespace HumanResourcesMenager.Infrastructure.Queries.Models
{
	public class GetEmployeesQueryModel : IRequest<IList<EmployeDTO>> { }
}
