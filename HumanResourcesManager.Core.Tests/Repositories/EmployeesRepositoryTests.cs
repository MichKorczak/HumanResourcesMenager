using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using HumanResourcesManager.Core.DbDomain;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Core.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HumanResourcesManager.Core.Tests.Repositories
{
	public class EmployeesRepositoryTests
	{
		private readonly DbContextOptions<HumanResourceContext> opt;
		private readonly HumanResourceContext context;
		private readonly EmployeesRepository sut;
		private readonly Fixture fixture;

		public EmployeesRepositoryTests()
		{
			opt = new DbContextOptionsBuilder<HumanResourceContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
			context = new HumanResourceContext(opt);
			sut = new EmployeesRepository(context);
			fixture = new Fixture();
		}

		[Fact]
		public async Task When_Get_Employees_Async_Then_Return_Full_List_Of_Employee()
		{
			// Arrange
			for (int i = 0; i < 5; i++)
			{
				context.Employees.Add(fixture.Build<Employee>().Without(x => x.Positions).Without(x => x.ManagerEmployee).Create());
				context.SaveChanges();
			}

			// Act
			var result = await sut.GetEmployeesAsync();

			// Assert
			result.Should().BeEquivalentTo(context.Employees);
		}


		[Fact]
		public async Task When_Add_Employee_Async_Then_Add_Employee_To_Context()
		{ 
			// Arrange
			var employee = fixture.Build<Employee>().Without(x => x.Positions).Without(x => x.ManagerEmployee).Create();

			// Act
			await sut.AddEmployeeAsync(employee);

			// Assert
			var result = context.Employees.Local.FirstOrDefault(x => x.Id == employee.Id);
			result.Should().NotBeNull();
			result.Should().Be(employee);
		}

		[Fact]
		public async Task When_Get_Employee_Async_Then_Return_Employee()
		{
			// Arrange
			var employee = fixture.Build<Employee>().Without(x => x.Positions).Without(x => x.ManagerEmployee).Create();
			context.Employees.Add(employee);
			context.SaveChanges();

			// Act
			var result = await sut.GetEmployeeAsync(employee.Id);

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType<Employee>();
			result.Should().Be(employee);
		}
	}
}
