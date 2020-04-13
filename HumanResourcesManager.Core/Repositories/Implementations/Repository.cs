using HumanResourcesManager.Core.Repositories.Abstract;

namespace HumanResourcesManager.Core.Repositories.Implementations
{
	public abstract class Repository : IRepository
	{
		protected Repository(IUnitOfWork unitOfWork)
		{
			UnitOfWork = unitOfWork;
		}

		public IUnitOfWork UnitOfWork { get; }
	}
}
