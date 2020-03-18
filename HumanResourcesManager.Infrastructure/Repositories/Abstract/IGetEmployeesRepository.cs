using System.Collections.Generic;
using System.Threading.Tasks;
using HumanResourcesManager.Core.Entities;

namespace HumanResourcesManager.Infrastructure.Repositories.Abstract
{
	public interface IGetEmployeesRepository
	{
		Task<IList<Employee>> GetEmployesAsync(); 
	}
}
