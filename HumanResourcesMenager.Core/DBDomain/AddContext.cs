using HumanResourcesMenager.Core.DBDomain.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResourcesMenager.Core.DBDomain
{
	public static class AddContext
	{
		public static void AddUserContext(this IServiceCollection services)
		{
			services.AddDbContext<UserContext>(options =>
						options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=UserContext;Trusted_Connection=True;MultipleActiveResultSets=true"));
		}
	}
}
