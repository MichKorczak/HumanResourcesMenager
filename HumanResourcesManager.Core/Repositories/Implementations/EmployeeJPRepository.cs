using System.Threading.Tasks;
using HumanResourcesManager.Core.DbDomain;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Core.Repositories.Abstract;

namespace HumanResourcesManager.Core.Repositories.Implementations
{
	public class EmployeeJPRepository : Repository, IEmployeeJPRepository
	{
		private readonly HumanResourceContext context;

		public EmployeeJPRepository(HumanResourceContext context) : base(context)
		{
			this.context = context;
		}

		public async Task AddEmployeeJobPositionAsync(EmployeeJobPosition model)
			=> await context.EmployeeJobPositions.AddAsync(model);

		public void RemoveEmployeeJobPositionAsync(EmployeeJobPosition model) => context.EmployeeJobPositions.Remove(model);
	}
}