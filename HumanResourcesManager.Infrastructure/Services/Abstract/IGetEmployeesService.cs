using HumanResourcesManager.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanResourcesManager.Infrastructure.Services.Abstract
{
	public interface IGetEmployeesService
	{
		Task<IList<Employee>> GetEmployesAsync(); 
	}
}
