using AutoMapper;
using HumanResourcesMenager.Api.Bus;
using HumanResourcesMenager.Core.DBDomain;
using HumanResourcesMenager.Core.DBDomain.Abstract;
using HumanResourcesMenager.Core.DBDomain.Implementation;
using HumanResourcesMenager.Infrastructure.Services.Abstract;
using HumanResourcesMenager.Infrastructure.Services.Implementations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HumanResourcesMenager.Api
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc(end => end.EnableEndpointRouting = false);
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
