using HumanResourcesMenager.Api.Bus;
using HumanResourcesMenager.Core.Entities;
using HumanResourcesMenager.Infrastructure.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesMenager.Api.Controllers
{
	[Route("api/employe")]
	[ApiController]
	public class EmployeController : Controller
	{
		private readonly IBus bus;

		public EmployeController(IBus bus)
		{
			this.bus = bus;
		}

		[HttpGet]
		public async Task<IActionResult> Get() =>
			Ok(await bus.SendAsync(new GetEmployeesQueryModel()));

	}
}
