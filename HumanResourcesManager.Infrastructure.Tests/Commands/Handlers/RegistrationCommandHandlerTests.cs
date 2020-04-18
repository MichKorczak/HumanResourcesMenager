using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Core.Exceptions;
using HumanResourcesManager.Core.Repositories.Abstract;
using HumanResourcesManager.Infrastructure.Commands.User;
using HumanResourcesManager.Infrastructure.Managers.Abstract;
using MediatR;
using Moq;
using Xunit;

namespace HumanResourcesManager.Infrastructure.Tests.Commands.Handlers
{
	public class RegistrationCommandHandlerTests
	{
		private readonly RegistrationCommandHandler sut;
		private readonly Mock<IUserRepository> userRepoMock;
		private readonly Mock<IEmployeesRepository> emploRepoMock;
		private readonly Mock<IPasswordEncrypt> passwordMock;
		private readonly Mock<IUnitOfWork> unitOfWorkMock;
		private readonly Fixture fixture;

		public RegistrationCommandHandlerTests()
		{
			userRepoMock = new Mock<IUserRepository>();
			emploRepoMock = new Mock<IEmployeesRepository>();
			passwordMock = new Mock<IPasswordEncrypt>();
			unitOfWorkMock = new Mock<IUnitOfWork>();
			userRepoMock.Setup(x => x.UnitOfWork).Returns(unitOfWorkMock.Object);
			unitOfWorkMock.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);
			sut = new RegistrationCommandHandler(userRepoMock.Object, emploRepoMock.Object, passwordMock.Object);
			fixture = new Fixture();
			var employee = fixture.Build<Employee>().Without(x => x.Positions).Without(x => x.ManagerEmployee).Create();
			emploRepoMock.Setup(x => x.GetEmployeeAsync(It.IsAny<Guid>())).ReturnsAsync(employee);
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Registration_Command_Then_Call_Get_Employee_Async_Once(RegistrationCommandModel model)
		{
			// Act
			await sut.Handle(model, default);

			// Assert
			emploRepoMock.Verify(x => x.GetEmployeeAsync(It.IsAny<Guid>()), Times.Once);
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Registration_Command_With_No_Existing_Employee_Then_Throw_Exception(RegistrationCommandModel model)
		{
			// Arrange
			Employee employee = null;
			emploRepoMock.Setup(x => x.GetEmployeeAsync(It.IsAny<Guid>())).ReturnsAsync(employee);

			// Act
			var ex = await Assert.ThrowsAsync<ManagerException>(() => sut.Handle(model, default));

			// Assert
			ex.Should().BeOfType<ManagerException>();
			ex.Message.Should().Be("Cannot create new user before register employee.");
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Registration_Command_Then_Call_Password_Encrypt_Once(RegistrationCommandModel model)
		{
			// Arrange
			byte[] salt, hash;

			// Act
			await sut.Handle(model, default);

			// Assert
			passwordMock.Verify(x => x.PasswordHash(It.IsAny<string>(), out salt, out hash), Times.Once);
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Registration_Command_Then_Call_Registration_Async_Once(RegistrationCommandModel model)
		{
			// Act
			await sut.Handle(model, default);

			// Assert
			userRepoMock.Verify(x => x.RegistrationAsync(It.Is<User>(a => a.UserName == model.UserName && 
			                                                              a.Email == model.Email && a.EmployeeId == model.EmployeeId)), Times.Once);
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Registration_Command_Then_Call_Save_Changes_Async_Once(RegistrationCommandModel model)
		{
			// Act
			await sut.Handle(model, default);

			// Assert
			userRepoMock.Verify(x => x.UnitOfWork.SaveChangesAsync(default), Times.Once);
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Registration_Command_Then_Return_Unit(RegistrationCommandModel model)
		{
			// Act
			var result = await sut.Handle(model, default);

			// Assert
			result.Should().BeOfType<Unit>();
		}
	}
}