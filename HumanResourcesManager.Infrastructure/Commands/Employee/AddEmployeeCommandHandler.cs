using System;
using System.Threading;
using System.Threading.Tasks;
using HumanResourcesManager.Core.Repositories.Abstract;
using HumanResourcesManager.Infrastructure.Interfaces;
using MediatR;

namespace HumanResourcesManager.Infrastructure.Commands.Employee
{
	public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommandModel, Guid>
	{
		private readonly IEmployeesRepository repository;
		private readonly IMapper mapper;

		public AddEmployeeCommandHandler(IEmployeesRepository repository, IMapper mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		public async Task<Guid> Handle(AddEmployeeCommandModel request, CancellationToken cancellationToken)
		{
			var employee = mapper.Map<AddEmployeeCommandModel, Core.Entities.Employee>(request);
			return await repository.AddEmployeeAsync(employee);
			
		}
	}
}
