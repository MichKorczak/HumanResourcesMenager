using System;
using HumanResourcesManager.Core.Dto;

namespace HumanResourcesManager.Infrastructure.Managers.Abstract
{
	public interface ITokenManager
	{
		TokenModel GetToken(Guid userId, string email, string role);
	}
}