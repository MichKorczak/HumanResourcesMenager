using HumanResourcesManager.Infrastructure.Queries.Employee;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HumanResourcesManager.Api.Bus;
using HumanResourcesManager.Core.DbDomain;

namespace HumanResourcesManager.Api.Controllers
{
	[Route("api/employee")]
	[ApiController]
	public class EmployeeController : Controller
	{
		private readonly IBus bus;

		public EmployeeController(IBus bus)
		{
			this.bus = bus;
		}

		[HttpGet]
		public async Task<IActionResult> Get() =>
			Ok(await bus.SendAsync(new GetEmployeesQueryModel()));

	}
}
