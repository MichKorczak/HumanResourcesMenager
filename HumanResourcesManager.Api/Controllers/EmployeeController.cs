using HumanResourcesManager.Infrastructure.Queries.Employee;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HumanResourcesManager.Api.Bus;

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
		public async Task<IActionResult> Get() =>
			Ok(await bus.SendAsync(new GetEmployeesQueryModel()));
	}
}
