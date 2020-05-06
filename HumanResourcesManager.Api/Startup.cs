using AutoMapper;
using HumanResourcesManager.Api.Bus;
using HumanResourcesManager.Api.Infrastructure;
using HumanResourcesManager.Core.DbDomain;
using HumanResourcesManager.Infrastructure.Registration;
using HumanResourcesManager.Infrastructure.Registration.Authorization;
using HumanResourcesManager.Infrastructure.Registration.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HumanResourcesManager.Api
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}
		
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc(end => end.EnableEndpointRouting = false);
			services.AddSettingsApplication(Configuration);
			services.AddContext();
			services.AddJwtAuth(Configuration);
			services.AddScoped<IBus, MediatrBus>();
			services.RegisterRepositories();
			services.AddSwaggerGen(s =>
			{
				s.SwaggerDoc("v1", new OpenApiInfo { Title = "HR API", Version = "v1" });
			});
			services.AddAutoMapper(InfrastructureAssembly.Application);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(u => 
				{
					u.SwaggerEndpoint("/swagger/v1/swagger.json", "HR API");
				});
				app.UseDeveloperExceptionPage();
			}
			app.UseMiddleware<CustomExceptionAttribute>();

			app.UseAuthentication();
			app.UseStaticFiles();
			app.UseMvc();
		}
	}
}
