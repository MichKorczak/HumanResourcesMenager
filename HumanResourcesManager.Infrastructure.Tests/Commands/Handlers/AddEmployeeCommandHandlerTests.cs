using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Core.Exceptions;
using HumanResourcesManager.Core.Repositories.Abstract;
using HumanResourcesManager.Infrastructure.Commands.Employee;
using MediatR;
using Moq;
using Xunit;

namespace HumanResourcesManager.Infrastructure.Tests.Commands.Handlers
{
	public class AddEmployeeCommandHandlerTests
	{
		private readonly Mock<IUnitOfWork> unitOfWorkMock;
		private readonly Mock<IEmployeesRepository> employeeRepositoryMock;
		private readonly Mock<IJobPositionRepository> jobRepositoryMock;
		private readonly Mock<IEmployeeJPRepository> employeeJpRepositoryMock;
		private readonly AddEmployeeCommandHandler sut;

		public AddEmployeeCommandHandlerTests()
		{
			unitOfWorkMock = new Mock<IUnitOfWork>();
			employeeRepositoryMock = new Mock<IEmployeesRepository>();
			jobRepositoryMock = new Mock<IJobPositionRepository>();
			employeeJpRepositoryMock = new Mock<IEmployeeJPRepository>();
			unitOfWorkMock.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);
			employeeRepositoryMock.Setup(x => x.UnitOfWork).Returns(unitOfWorkMock.Object);
			sut = new AddEmployeeCommandHandler(employeeRepositoryMock.Object, jobRepositoryMock.Object, employeeJpRepositoryMock.Object);
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Add_Employee_Command_Then_Add_Employee_To_Repository(AddEmployeeCommandModel model)
		{
			// Act
			await sut.Handle(model, default);

			// Assert
			employeeRepositoryMock.Verify(x 
				=> x.AddEmployeeAsync(It.Is<Employee>(a => a.FirstName == model.FirstName 
				                                           && a.LastName == model.LastName && a.Address == model.Address
				                                           && a.DateOfBirth == model.DateOfBirth)), Times.Once);
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Add_Employee_Command_Then_Save_Changes_Once(AddEmployeeCommandModel model)
		{
			// Act
			await sut.Handle(model, default);

			// Assert
			employeeRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(default), Times.Once);
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Add_Employee_Command_Then_Returns_Unit(AddEmployeeCommandModel model)
		{
			// Act
			var result = await sut.Handle(model, default);

			// Assert
			result.Should().BeOfType<Unit>();
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Add_Employee_Command_And_Cannot_Save_Then_Throw_Exception(AddEmployeeCommandModel model)
		{
			// Arrange
			unitOfWorkMock.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(0);

			// Act
			var ex = await Assert.ThrowsAsync<ManagerException>(() => sut.Handle(model, default));

			// Assert
			ex.Should().BeOfType<ManagerException>();
			ex.Message.Should().Be("Cannot create new user before register employee.");
		}
	}
}
