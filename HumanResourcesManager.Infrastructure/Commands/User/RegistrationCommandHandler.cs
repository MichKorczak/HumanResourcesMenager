using System;
using System.Threading;
using System.Threading.Tasks;
using HumanResourcesManager.Core.Repositories.Abstract;
using HumanResourcesManager.Infrastructure.Managers.Abstract;
using MediatR;

namespace HumanResourcesManager.Infrastructure.Commands.User
{
	public class RegistrationCommandHandler : IRequestHandler<RegistrationCommandModel>
	{
		private readonly IEmployeesRepository employeesRepository;
		private readonly IPasswordEncrypt encrypt;
		private readonly IUserRepository userRepository;

		public RegistrationCommandHandler(IUserRepository userRepository, IEmployeesRepository employeesRepository, IPasswordEncrypt encrypt)
		{
			this.employeesRepository = employeesRepository;
			this.encrypt = encrypt;
			this.userRepository = userRepository;
		}

		public async Task<Unit> Handle(RegistrationCommandModel request, CancellationToken cancellationToken)
		{
			var employee = await employeesRepository.GetEmployeeAsync(request.EmployeeId);
			if (employee == null)
			{
				throw new Exception("Cannot create new user before register employee");
			}

			encrypt.PasswordHash(request.Password, out var salt, out var passwordHash);

			Core.Entities.User user = new Core.Entities.User(request.UserName, request.Email, DateTime.Now, salt, passwordHash, request.EmployeeId) { Employee = employee };

			await userRepository.RegistrationAsync(user);
			await userRepository.UnitOfWork.SaveChangesAsync(default);
			return Unit.Value;
		}
	}
}