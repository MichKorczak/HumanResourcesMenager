using HumanResourcesManager.Core.DbDomain.Abstract;
using HumanResourcesManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesManager.Core.DbDomain.Implementation
{
	public class UserContext : DbContext, IUserContext
	{
		public UserContext(DbContextOptions<UserContext> opt) : base(opt)
		{
		}

		public DbSet<Employee> Employes { get; set; }
	}
}
