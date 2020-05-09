using System;
using HumanResourcesManager.Core.Dto;
using MediatR;

namespace HumanResourcesManager.Infrastructure.Queries.Employee
{
	public class GetEmployeeQueryModel : IRequest<EmployeeDto>
	{
		public GetEmployeeQueryModel(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; }
	}
}