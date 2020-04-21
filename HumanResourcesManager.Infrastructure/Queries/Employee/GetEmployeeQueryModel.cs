using System;
using HumanResourcesManager.Core.Dto;
using MediatR;

namespace HumanResourcesManager.Infrastructure.Queries.Employee
{
	public class GetEmployeeQueryModel : IRequest<EmployeeDto>
	{
		public Guid Id { get; }

		public GetEmployeeQueryModel(Guid id)
		{
			Id = id;
		}
	}
}