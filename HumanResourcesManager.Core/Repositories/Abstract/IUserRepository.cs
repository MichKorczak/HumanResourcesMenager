using System.Threading.Tasks;
using HumanResourcesManager.Core.Entities;

namespace HumanResourcesManager.Core.Repositories.Abstract
{
	public interface IUserRepository : IRepository
	{
		Task RegistrationAsync(User user);

		Task<User> GetUser(string login);
	}
}
