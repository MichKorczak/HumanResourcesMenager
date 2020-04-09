namespace HumanResourcesManager.Core.Repositories.Abstract
{
	public interface IRepository
	{
		IUnitOfWork UnitOfWork { get; }
	}
}
