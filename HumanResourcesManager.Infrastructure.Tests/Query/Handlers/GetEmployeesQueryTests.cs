using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using HumanResourcesManager.Core.Dto;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Core.Repositories.Abstract;
using HumanResourcesManager.Infrastructure.Interfaces;
using HumanResourcesManager.Infrastructure.Queries.Employee;
using Moq;
using Xunit;

namespace HumanResourcesManager.Infrastructure.Tests.Query.Handlers
{
	public class GetEmployeesQueryTests
	{
		private readonly Mock<IEmployeesRepository> employeeRepositoryMock;
		private readonly Mock<IMapper> mapperMock;
		private readonly GetEmployeesQueryHandler sut;
		private readonly Fixture fixture;

		public GetEmployeesQueryTests()
		{
			employeeRepositoryMock = new Mock<IEmployeesRepository>();
			mapperMock = new Mock<IMapper>();
			//System under test
			sut = new GetEmployeesQueryHandler(employeeRepositoryMock.Object, mapperMock.Object);
			fixture = new Fixture();
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Query_Then_Gets_Employee_From_Repository(GetEmployeesQueryModel model)
		{
			// Act
			await sut.Handle(model, default);

			// Assert
			employeeRepositoryMock.Verify(x => x.GetEmployesAsync(), Times.Once);
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Query_Then_Maps_Employees_To_EmployeeDtos(GetEmployeesQueryModel model)
		{
			// Arrange 
			var employee = fixture.Build<Employee>().Without(x => x.Positions).Without(x => x.ManagerEmployee).Create();
			var employees = new Employee[] { employee }; 
			employeeRepositoryMock.Setup(x => x.GetEmployesAsync()).ReturnsAsync(employees);

			// Act
			await sut.Handle(model, default);

			// Assert
			mapperMock.Verify(x => x.MapCollection<Employee, EmployeeDto>(employees), Times.Once);
		}

		[Theory]
		[AutoData]
		public async Task When_Handling_Query_Then_Returns_Mapped_EmployeeDtos(GetEmployeesQueryModel model, EmployeeDto[] employees)
		{
			// Arrange 
			mapperMock.Setup(x => x.MapCollection<Employee, EmployeeDto>(It.IsAny<IEnumerable<Employee>>())).Returns(employees);

			// Act
			var result =  (await sut.Handle(model, default)).ToList();

			// Assert
			result.Should().NotBeNullOrEmpty();
			result.Should().BeEquivalentTo<EmployeeDto>(employees);
		}
	}
}
