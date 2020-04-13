using System.Threading;
using System.Threading.Tasks;

namespace HumanResourcesManager.Core.Repositories.Abstract
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}