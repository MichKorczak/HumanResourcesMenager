using HumanResourcesManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesManager.Core.DbDomain.Abstract
{
	public interface IUserContext
	{
		DbSet<Employee> Employes { get; set; }
	}
}
