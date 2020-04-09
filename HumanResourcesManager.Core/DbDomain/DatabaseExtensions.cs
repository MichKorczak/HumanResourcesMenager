using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HumanResourcesManager.Core.DbDomain
{
	public static class DatabaseExtensions
	{
		public static void AddContext(this IServiceCollection services)
		{
			var databaseSettings = services.BuildServiceProvider()
				.GetRequiredService<IOptions<DatabaseSettings>>().Value;
			services.AddDbContext<HumanResourceContext>(options =>
						options.UseSqlServer(databaseSettings.ConnectionString));
		}
	}
}
