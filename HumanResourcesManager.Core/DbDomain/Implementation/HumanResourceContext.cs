using HumanResourcesManager.Core.DbDomain.Abstract;
using HumanResourcesManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesManager.Core.DbDomain.Implementation
{
	public class HumanResourceContext : DbContext, IHumanResourceContext
	{
		public HumanResourceContext(DbContextOptions<HumanResourceContext> options) : base(options)
		{
		}

		public DbSet<Employee> Employes { get; set; }
	}
}
