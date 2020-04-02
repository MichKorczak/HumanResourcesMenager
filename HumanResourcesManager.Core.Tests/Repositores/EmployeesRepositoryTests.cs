using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using HumanResourcesManager.Core.DbDomain.Abstract;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Core.Repositories.Implementations;
using MockQueryable.Moq;
using Moq;
using Xunit;

namespace HumanResourcesManager.Core.Tests.Repositores
{
	public class EmployeesRepositoryTests
	{
		private readonly Mock<IHumanResourceContext> contextMock;
		private readonly EmployeesRepository sut;

		public EmployeesRepositoryTests()
		{
			contextMock = new Mock<IHumanResourceContext>();
			sut = new EmployeesRepository(contextMock.Object);
		}

		[Theory]
		[AutoData]
		public async Task When_Request_Come_Then_Return_Full_List_Of_Employee(IEnumerable<Employee> employees)
		{
			// Arrange
			var mock = employees.AsQueryable().BuildMockDbSet();
			contextMock.Setup(x => x.Employees).Returns(mock.Object);

			// Act
			var result = await sut.GetEmployesAsync();

			// Assert
			var shouldBe = employees.AsEnumerable();
			result.Should().BeEquivalentTo<Employee>(shouldBe);
		}


		[Theory]
		[AutoData]
		public async Task When_Request_Come_Then_Add_Employee_To_Context(IEnumerable<Employee> employees, Employee employee)
		{
			// Arrange
			var mock = employees.AsQueryable().BuildMockDbSet();
			contextMock.Setup(x => x.Employees).Returns(mock.Object);

			// Act
			var result = await sut.AddEmployeeAsync(employee);

			// Assert
			result.Should().Be(employee.Id);
		}
	}

	
}
