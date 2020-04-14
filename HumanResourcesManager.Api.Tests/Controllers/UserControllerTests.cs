using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using HumanResourcesManager.Api.Bus;
using HumanResourcesManager.Api.Controllers;
using HumanResourcesManager.Infrastructure.Commands.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace HumanResourcesManager.Api.Tests.Controllers
{
	public class UserControllerTests
	{
		private readonly UserController sut;
		private readonly Mock<IBus> busMock;

		public UserControllerTests()
		{
			busMock = new Mock<IBus>();
			sut = new UserController(busMock.Object);
		}

		[Theory]
		[AutoData]
		public async Task When_Registration_Then_Send_Registration_Command_Model_With_Bus(
			RegistrationCommandModel model)
		{
			// Act 
			await sut.Registration(model);

			// Assert
			busMock.Verify(x => x.SendAsync(It.IsAny<RegistrationCommandModel>(), default), Times.Once);
		}

		[Theory]
		[AutoData]
		public async Task When_Registration_Then_Response_Accepted(RegistrationCommandModel model)
		{
			// Act
			var response = await sut.Registration(model);

			// Assert
			response.Should().BeOfType<AcceptedResult>();
		}
	}
}