using System.Threading;
using System.Threading.Tasks;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Core.Exceptions;
using HumanResourcesManager.Core.Repositories.Abstract;
using MediatR;

namespace HumanResourcesManager.Infrastructure.Commands.Employee
{
	public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommandModel>
	{
		private readonly IEmployeesRepository employeesRepository;
		private readonly IJobPositionRepository positionRepository;
		private readonly IEmployeeJPRepository employeeJpRepository;

		public AddEmployeeCommandHandler(IEmployeesRepository employeesRepository, IJobPositionRepository positionRepository, IEmployeeJPRepository employeeJpRepository)
		{
			this.employeesRepository = employeesRepository;
			this.positionRepository = positionRepository;
			this.employeeJpRepository = employeeJpRepository;
		}


		public async Task<Unit> Handle(AddEmployeeCommandModel request, CancellationToken cancellationToken)
		{
			var employee = new Core.Entities.Employee(request.FirstName, request.LastName, request.DateOfBirth, request.Address);
			var jobPosition = await positionRepository.GetJobPositionAsync(request.Position);

			if (jobPosition == null)
			{
				throw new ManagerException(ErrorsMessage.JobPositionDoesNotExist);
			}

			var employeeJobPositionModel = new EmployeeJobPosition(jobPosition, employee);
			await employeeJpRepository.AddEmployeeJobPositionAsync(employeeJobPositionModel);

			employee.MainRole = request.Position;
			employee.Positions.Add(employeeJobPositionModel);

			await employeesRepository.AddEmployeeAsync(employee);
			await employeesRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
