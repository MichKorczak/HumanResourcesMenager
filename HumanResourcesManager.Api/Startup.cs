using AutoMapper;
using HumanResourcesManager.Api.Bus;
using HumanResourcesManager.Core.DbDomain;
using HumanResourcesManager.Infrastructure.Repositories.Abstract;
using HumanResourcesManager.Infrastructure.Repositories.Implementations;
using MediatR;
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
		private const string DatabaseSettings = "DatabaseSettings";
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}
		
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc(end => end.EnableEndpointRouting = false);
			services.Configure<DatabaseSettings>(Configuration.GetSection(DatabaseSettings));
			services.AddUserContext();
			services.AddScoped<IBus, MediatrBus>();
			services.AddScoped<IGetEmployeesRepository, GetEmployeesRepository>();
			services.AddMediatR(typeof(IGetEmployeesRepository), typeof(GetEmployeesRepository));
			services.AddSwaggerGen(s =>
			{
				s.SwaggerDoc("v1", new OpenApiInfo { Title = "HR API", Version = "v1" });
			});
			services.AddAutoMapper(typeof(Startup));
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
			app.UseStaticFiles();
			app.UseMvc();
		}
	}
}