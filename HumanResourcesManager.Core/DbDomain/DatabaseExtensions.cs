using HumanResourcesManager.Core.DbDomain.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HumanResourcesManager.Core.DbDomain
{
	public static class DatabaseExtensions
	{
		public static void AddUserContext(this IServiceCollection services)
		{
			var databaseConnectionStrings = services.BuildServiceProvider().GetRequiredService<IOptions<ConnectionStringOptions>>()
				.Value;
			services.AddDbContext<UserContext>(options =>
						options.UseSqlServer(databaseConnectionStrings.ConnectionStrings));
		}
	}
}
