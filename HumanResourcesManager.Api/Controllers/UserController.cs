using System.Threading.Tasks;
using HumanResourcesManager.Api.Bus;
using HumanResourcesManager.Infrastructure.Commands.User;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourcesManager.Api.Controllers
{
	[Route("api/user")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly IBus bus;

		public UserController(IBus bus)
		{
			this.bus = bus;
		}

		public async Task<IActionResult> Registration(RegistrationCommandModel model)
		{
			await bus.SendAsync(model);
			return Accepted();
		}
	}
}