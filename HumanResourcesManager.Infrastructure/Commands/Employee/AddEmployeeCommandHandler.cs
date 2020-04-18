using System.Threading;
using System.Threading.Tasks;
using HumanResourcesManager.Core.Exceptions;
using HumanResourcesManager.Core.Repositories.Abstract;
using MediatR;

namespace HumanResourcesManager.Infrastructure.Commands.Employee
{
	public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommandModel>
	{
		private readonly IEmployeesRepository employeesRepository;

		public AddEmployeeCommandHandler(IEmployeesRepository employeesRepository)
		{
			this.employeesRepository = employeesRepository;
		}


		public async Task<Unit> Handle(AddEmployeeCommandModel request, CancellationToken cancellationToken)
		{
			var employee = new Core.Entities.Employee(request.FirstName, request.LastName, request.DateOfBirth, request.Address);
			await employeesRepository.AddEmployeeAsync(employee);
			if (await employeesRepository.UnitOfWork.SaveChangesAsync(cancellationToken) < 1)
			{
				throw new ManagerException(ErrorsMessage.ContentSaveError);
			}

			return Unit.Value;
		}
	}
}
