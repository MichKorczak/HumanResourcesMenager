using System.ComponentModel.DataAnnotations;
using System.Text;
using HumanResourcesManager.Core.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace HumanResourcesManager.Infrastructure.Registration.Authorization
{
	public static class AuthRegistration
	{
		public static void AddJwtAuth(this IServiceCollection services, IConfiguration configuration)
		{
			var appSettingsSection = configuration.GetSection("AuthSettings");
			services.Configure<JwtSettings>(appSettingsSection);

			var appSettings = appSettingsSection.Get<JwtSettings>();
			var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});
		}
	}
}