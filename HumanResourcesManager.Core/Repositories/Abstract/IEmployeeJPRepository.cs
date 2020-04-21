using System.Threading.Tasks;
using HumanResourcesManager.Core.Entities;

namespace HumanResourcesManager.Core.Repositories.Abstract
{
	public interface IEmployeeJPRepository : IRepository
	{
		Task AddEmployeeJobPositionAsync(EmployeeJobPosition model);

		void RemoveEmployeeJobPositionAsync(EmployeeJobPosition model);
	}
}