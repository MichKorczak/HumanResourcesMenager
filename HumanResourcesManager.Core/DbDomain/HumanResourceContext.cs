using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Core.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesManager.Core.DbDomain
{
	public class HumanResourceContext : DbContext, IUnitOfWork
	{
		public HumanResourceContext()
		{
		}

		public HumanResourceContext(DbContextOptions<HumanResourceContext> options)
			: base(options)
		{
		}

		public DbSet<Employee> Employees { get; set; }

		public DbSet<User> Users { get; set; }

		public DbSet<JobPosition> JobPositions { get; set; }

		public DbSet<EmployeeJobPosition> EmployeeJobPositions { get; set; }
	}
}
