using System.Threading.Tasks;
using HumanResourcesManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesManager.Core.DbDomain.Abstract
{
	public interface IHumanResourceContext 
	{
		DbSet<Employee> Employees { get; set; }

		Task<bool> SaveAsync();
	}
}
