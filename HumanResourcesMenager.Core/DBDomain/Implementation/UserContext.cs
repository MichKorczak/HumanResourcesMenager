using HumanResourcesMenager.Core.DBDomain.Abstract;
using HumanResourcesMenager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesMenager.Core.DBDomain.Implementation
{
	public class UserContext : DbContext, IUserContext
	{
		public UserContext(DbContextOptions<UserContext> opt) : base(opt)
		{
		}

		public DbSet<Employe> Employes { get; set; }
	}
}
