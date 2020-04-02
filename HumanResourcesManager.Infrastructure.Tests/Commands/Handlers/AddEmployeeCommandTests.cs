using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Core.Repositories.Abstract;
using HumanResourcesManager.Infrastructure.Commands.Employee;
using HumanResourcesManager.Infrastructure.Interfaces;
using Moq;
using Xunit;

namespace HumanResourcesManager.Infrastructure.Tests.Commands.Handlers
{
	public class AddEmployeeCommandTests
	{
		private readonly Mock<IEmployeesRepository> employeeRepositoryMock;
		private readonly Mock<IMapper> mapperMock;
		private readonly AddEmployeeCommandHandler sut;

		public AddEmployeeCommandTests()
		{
			employeeRepositoryMock = new Mock<IEmployeesRepository>();
			mapperMock = new Mock<IMapper>();
			sut = new AddEmployeeCommandHandler(employeeRepositoryMock.Object, mapperMock.Object);
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Command_Then_Add_Employee_To_Repository(AddEmployeeCommandModel model, Employee employee)
		{
			// Arrange
			mapperMock.Setup(x => x.Map<AddEmployeeCommandModel, Employee>(model)).Returns(employee);

			// Act
			await sut.Handle(model, default);

			// Assert
			employeeRepositoryMock.Verify(x => x.AddEmployeeAsync(employee), Times.Once);
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Command_Then_Maps_AddEmployeeCommandModel_To_Employee(AddEmployeeCommandModel model, Employee employee)
		{
			// Arrange 
			employeeRepositoryMock.Setup(x => x.AddEmployeeAsync(employee)).ReturnsAsync(employee.Id);

			// Act
			await sut.Handle(model, default);

			// Assert
			mapperMock.Verify(x => x.Map<AddEmployeeCommandModel, Employee>(model), Times.Once);
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Command_Then_Returns_Id_Employee(AddEmployeeCommandModel model, Employee employee)
		{
			// Arrange 
			employeeRepositoryMock.Setup(x => x.AddEmployeeAsync(It.IsAny<Employee>())).ReturnsAsync(employee.Id);

			// Act
			var result = await sut.Handle(model, default);

			// Assert
			result.Should().NotBeEmpty();
			result.Should().Be(employee.Id);
		}
	}
}
