using System.Linq;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using HumanResourcesManager.Core.DbDomain.Abstract;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Core.Repositories.Abstract;
using HumanResourcesManager.Core.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
		public async Task When_Request_Come_Then_Return_Full_List_Of_Employee(DbSet<Employee> employees)
		{
			// Arrange
			contextMock.Setup(x => x.Employees).Returns(employees);

			// Act
			var result = await sut.GetEmployesAsync();

			// Assert
			result.Should().BeEquivalentTo(employees);

		}
	}
}
