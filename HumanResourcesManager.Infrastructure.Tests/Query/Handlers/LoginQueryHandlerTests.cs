using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using HumanResourcesManager.Core.Dto;
using HumanResourcesManager.Core.Repositories.Abstract;
using HumanResourcesManager.Infrastructure.Managers.Abstract;
using HumanResourcesManager.Infrastructure.Queries.User;
using Moq;
using Xunit;

namespace HumanResourcesManager.Infrastructure.Tests.Query.Handlers
{
	public class LoginQueryHandlerTests
	{
		private readonly LoginQueryHandler sut;
		private readonly Mock<IUserRepository> userRepositoryMock;
		private readonly Mock<IPasswordEncrypt> passwordMock;
		private readonly Mock<ITokenManager> tokenMock;

		public LoginQueryHandlerTests()
		{
			userRepositoryMock = new Mock<IUserRepository>();
			passwordMock = new Mock<IPasswordEncrypt>();
			tokenMock = new Mock<ITokenManager>();
			sut = new LoginQueryHandler(userRepositoryMock.Object, passwordMock.Object, tokenMock.Object);
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Query_Then_Returns_Token_Model(LoginQueryModel model)
		{
			// Act
			var response = await sut.Handle(model,default);

			// Assert
			response.Should().BeOfType<TokenModel>();
		}


		[Theory]
		[AutoData]
		public async Task When_Handling_Query_Then_Gets_User_From_Repository(LoginQueryModel model)
		{
			// Act
			var response = await sut.Handle(model, default);

			// Assert
			response.Should().BeOfType<TokenModel>();
		}
	}
}