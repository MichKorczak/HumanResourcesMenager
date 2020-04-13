using System.Threading;
using System.Threading.Tasks;
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
			await employeesRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
			return Unit.Value;
		}
	}
}
