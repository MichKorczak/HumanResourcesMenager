
using HumanResourcesManager.Core.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResourcesManager.Infrastructure.Registration.Modules
{
	public static class SettingsExtensions
	{
		private const string DatabaseSettings = "DatabaseSettings";
		private const string AuthSettings = "AuthSettings";

		public static void AddSettingsApplication(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<DatabaseSettings>(configuration.GetSection(DatabaseSettings));
			services.Configure<JwtSettings>(configuration.GetSection(AuthSettings));
		}
	}
}