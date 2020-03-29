using HumanResourcesManager.Core.Repositories.Abstract;
using HumanResourcesManager.Core.Repositories.Implementations;
using HumanResourcesManager.Infrastructure.Interfaces;
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
			services.AddScoped<IMapper, Services.Mapper>();
		}
	}
}
