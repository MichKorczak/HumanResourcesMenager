using System;
using System.Threading;
using System.Threading.Tasks;
using HumanResourcesManager.Core.Dto;
using HumanResourcesManager.Core.Exceptions;
using HumanResourcesManager.Core.Repositories.Abstract;
using HumanResourcesManager.Infrastructure.Managers.Abstract;
using MediatR;

namespace HumanResourcesManager.Infrastructure.Queries.User
{
	public class LoginQueryHandler : IRequestHandler<LoginQueryModel, TokenModel>
	{
		private readonly IUserRepository userRepository;
		private readonly IPasswordEncrypt encrypt;
		private readonly ITokenManager manager;

		public LoginQueryHandler(IUserRepository userRepository, IPasswordEncrypt encrypt, ITokenManager manager)
		{
			this.userRepository = userRepository;
			this.encrypt = encrypt;
			this.manager = manager;
		}

		public async Task<TokenModel> Handle(LoginQueryModel request, CancellationToken cancellationToken)
		{
			var user = await userRepository.GetUser(request.Login);

			if (user == null || !encrypt.VerificationPasswordHash(request.Password, user.PasswordHash, user.Salt))
			{
				throw new ManagerException(ErrorsMessage.LoginError);
			}

			return manager.GetToken(user.Id, user.Email, user.MainRole);
		}
	}
}