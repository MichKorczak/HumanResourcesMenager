using System.Threading.Tasks;
using HumanResourcesManager.Core.Entities;

namespace HumanResourcesManager.Core.Repositories.Abstract
{
	public interface IJobPositionRepository : IRepository
	{
		Task<JobPosition> GetJobPositionAsync(string jobPositionName);

		Task AddJobPositionAsync(JobPosition model);
	}
}