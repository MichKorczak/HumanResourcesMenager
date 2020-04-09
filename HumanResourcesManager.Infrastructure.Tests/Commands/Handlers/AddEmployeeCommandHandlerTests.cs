using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Core.Repositories.Abstract;
using HumanResourcesManager.Infrastructure.Commands.Employee;
using HumanResourcesManager.Infrastructure.Tests.Helpers;
using MediatR;
using Moq;
using Xunit;

namespace HumanResourcesManager.Infrastructure.Tests.Commands.Handlers
{
	public class AddEmployeeCommandHandlerTests
	{
		private readonly Mock<IEmployeesRepository> employeeRepositoryMock;
		private readonly AddEmployeeCommandHandler sut;

		public AddEmployeeCommandHandlerTests()
		{
			employeeRepositoryMock = new Mock<IEmployeesRepository>();
			sut = new AddEmployeeCommandHandler(employeeRepositoryMock.Object);
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Add_Employee_Command_Then_Create_Employee(AddEmployeeCommandModel model)
		{
			// Arrange
			employeeRepositoryMock.Setup(x => x.AddEmployeeAsync(It.IsAny<Employee>()));
			employeeRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));
			Employee employee = new Employee(model.FirstName, model.LastName, model.DateOfBirth, model.Address);

			// Act
			await sut.Handle(model, default);

			// Assert
			employeeRepositoryMock.Verify(x => x.AddEmployeeAsync(It.Is<Employee>(a => a.EqualEmployees(employee))));
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Add_Employee_Command_Then_Add_Employee_To_Repository(AddEmployeeCommandModel model)
		{
			// Arrange
			employeeRepositoryMock.Setup(x => x.AddEmployeeAsync(It.IsAny<Employee>()));
			employeeRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));

			// Act
			await sut.Handle(model, default);

			// Assert
			employeeRepositoryMock.Verify(x => x.AddEmployeeAsync(It.IsAny<Employee>()), Times.Once);
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Add_Employee_Command_Then_Get_SaveChangesAsync_Once(AddEmployeeCommandModel model)
		{
			// Arrange 
			employeeRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));
			employeeRepositoryMock.Setup(x => x.AddEmployeeAsync(It.IsAny<Employee>()));

			// Act
			await sut.Handle(model, default);

			// Assert
			employeeRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(default), Times.Once);
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Add_Employee_Command_Then_Returns_Unit(AddEmployeeCommandModel model)
		{
			// Arrange 
			employeeRepositoryMock.Setup(x => x.AddEmployeeAsync(It.IsAny<Employee>()));
			employeeRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));
			
			// Act
			var result = await sut.Handle(model, default);

			// Assert
			result.Should().BeOfType<Unit>();
		}
	}
}
