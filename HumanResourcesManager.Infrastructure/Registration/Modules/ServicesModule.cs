using HumanResourcesManager.Core.Repositories.Abstract;
using HumanResourcesManager.Core.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResourcesManager.Infrastructure.Registration.Modules
{
	public static class ServicesModule 
	{
		public static void Registration(this IServiceCollection services)
		{
			services.AddScoped<IEmployeesRepository, EmployeesRepository>();
		}
	}
}
