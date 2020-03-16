using AutoMapper;
using HumanResourcesManager.Api.Bus;
using HumanResourcesManager.Core.DbDomain;
using HumanResourcesManager.Core.DbDomain.Abstract;
using HumanResourcesManager.Core.DbDomain.Implementation;
using HumanResourcesManager.Infrastructure.Services.Abstract;
using HumanResourcesManager.Infrastructure.Services.Implementations;
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
		private const string ConnectionStringOptions = "ConnectionStringOptions";
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc(end => end.EnableEndpointRouting = false);
			services.Configure<ConnectionStringOptions>(Configuration.GetSection(ConnectionStringOptions));
			services.AddUserContext();
			services.AddScoped<IUserContext, UserContext>();
			services.AddScoped<IBus, MediatrBus>();
			services.AddScoped<IGetEmployeesService, GetEmployeesService>();
			services.AddMediatR(typeof(IGetEmployeesService), typeof(GetEmployeesService));
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
