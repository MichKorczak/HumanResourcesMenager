﻿using System;
using System.Threading.Tasks;
using HumanResourcesManager.Api.Bus;
using HumanResourcesManager.Infrastructure.Commands.Employee;
using HumanResourcesManager.Infrastructure.Queries.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourcesManager.Api.Controllers
{
	[Route("api/employees")]
	[ApiController]
	public class EmployeesController : Controller
	{
		private readonly IBus bus;

		public EmployeesController(IBus bus)
		{
			this.bus = bus;
		}

		[HttpGet]
		public async Task<IActionResult> GetEmployeesAsync()
		{
			var result = await bus.SendAsync(new GetEmployeesQueryModel());
			return Ok(result);
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetEmployeeAsync(Guid id)
		{
			var result = await bus.SendAsync(new GetEmployeeQueryModel(id));
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> CreateEmployeesAsync(AddEmployeeCommandModel model)
		{
			await bus.SendAsync(model);
			return Accepted();
		}
	}
}
