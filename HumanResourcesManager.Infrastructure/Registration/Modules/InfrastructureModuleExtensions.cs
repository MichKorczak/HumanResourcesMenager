using HumanResourcesManager.Core.Repositories.Abstract;
using HumanResourcesManager.Core.Repositories.Implementations;
using HumanResourcesManager.Infrastructure.Interfaces;
using HumanResourcesManager.Infrastructure.Managers.Abstract;
using HumanResourcesManager.Infrastructure.Managers.Implementations;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResourcesManager.Infrastructure.Registration.Modules
{
	public static class InfrastructureModuleExtensions 
	{
		public static void RegisterRepositories(this IServiceCollection services)
		{
			services.AddMediatR(InfrastructureAssembly.Application);
			services.AddScoped<IEmployeesRepository, EmployeesRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IMapper, Services.Mapper>();
			services.AddScoped<IPasswordEncrypt, PasswordEncrypt>();
		}
	}
}
