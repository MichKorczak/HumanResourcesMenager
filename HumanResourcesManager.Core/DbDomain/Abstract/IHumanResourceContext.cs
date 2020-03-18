using HumanResourcesManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesManager.Core.DbDomain.Abstract
{
	public interface IHumanResourceContext
	{
		DbSet<Employee> Employes { get; set; }
	}
}
