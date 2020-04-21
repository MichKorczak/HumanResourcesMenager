using System.Threading.Tasks;
using HumanResourcesManager.Core.DbDomain;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Core.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesManager.Core.Repositories.Implementations
{
	public class JobPositionRepository : Repository, IJobPositionRepository
	{
		private readonly HumanResourceContext context;

		public JobPositionRepository(HumanResourceContext context) : base(context)
		{
			this.context = context;
		}

		public async Task<JobPosition> GetJobPositionAsync(string jobPositionName) 
			=> await context.JobPositions.FirstOrDefaultAsync(x => x.PositionName == jobPositionName);

		public async Task AddJobPositionAsync(JobPosition model) => await context.JobPositions.AddAsync(model);
	}
}