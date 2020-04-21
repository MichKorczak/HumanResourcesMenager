using System.Threading;
using System.Threading.Tasks;
using HumanResourcesManager.Core.Dto;
using HumanResourcesManager.Core.Exceptions;
using HumanResourcesManager.Core.Repositories.Abstract;
using HumanResourcesManager.Infrastructure.Interfaces;
using MediatR;

namespace HumanResourcesManager.Infrastructure.Queries.Employee
{
	public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQueryModel, EmployeeDto>
	{
		private readonly IEmployeesRepository repository;
		private readonly IMapper mapper;

		public GetEmployeeQueryHandler(IEmployeesRepository repository, IMapper mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		public async Task<EmployeeDto> Handle(GetEmployeeQueryModel request, CancellationToken cancellationToken)
		{
			var response = await repository.GetEmployeeAsync(request.Id);
			if (response == null)
			{
				throw new ManagerException(ErrorsMessage.WrongId);
			}

			var responseDto = mapper.Map<Core.Entities.Employee, EmployeeDto>(response);
			return responseDto;
		}
	}
}