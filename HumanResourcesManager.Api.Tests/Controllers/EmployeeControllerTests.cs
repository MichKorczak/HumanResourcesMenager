using System;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using HumanResourcesManager.Api.Bus;
using HumanResourcesManager.Api.Controllers;
using HumanResourcesManager.Core.Dto;
using HumanResourcesManager.Infrastructure.Commands.Employee;
using HumanResourcesManager.Infrastructure.Queries.Employee;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace HumanResourcesManager.Api.Tests.Controllers
{
	public class EmployeeControllerTests
	{
		private readonly Mock<IBus> busMock;
		private readonly EmployeesController sut;

		public EmployeeControllerTests()
		{
			busMock = new Mock<IBus>();
			sut = new EmployeesController(busMock.Object);
		}

		[Fact]
		public async Task When_Getting_Employee_Then_Sends_Get_Employee_Query_Model_With_Bus()
		{
			// Act
			await sut.GetEmployeesAsync();

			// Assert
			busMock.Verify(x => x.SendAsync(It.IsAny<GetEmployeesQueryModel>(), default), Times.Once);
		}

		[Theory]
		[AutoData]
		public async Task When_Getting_Employees_List_Then_Return_Ok_Result_With_List(EmployeeDto[] employees)
		{
			// Arrange
			busMock.Setup(x => x.SendAsync(It.IsAny<GetEmployeesQueryModel>(), default)).ReturnsAsync(employees);

			// Act
			var response = await sut.GetEmployeesAsync();

			// Assert
			response.Should().BeOfType<OkObjectResult>();
			var objectResult = response.As<OkObjectResult>();
			objectResult.Value.Should().BeOfType<EmployeeDto[]>();
			var dtos = objectResult.Value.As<EmployeeDto[]>();
			dtos.Should().BeEquivalentTo<EmployeeDto>(employees);
		}

		[Theory]
		[AutoData]
		public async Task When_Adding_Employee_Then_Sends_Command_Add_Employee_Handler(AddEmployeeCommandModel model)
		{
			// Act
			await sut.CreateEmployeesAsync(model);

			// Assert
			busMock.Verify(x => x.SendAsync(It.IsAny<AddEmployeeCommandModel>(), default), Times.Once);
		}

		[Theory]
		[AutoData]
		public async Task When_Adding_Employee_With_Complete_Object_Then_Response_Accepted(AddEmployeeCommandModel model)
		{ 
			// Act
			var response = await sut.CreateEmployeesAsync(model);

			// Assert
			response.Should().BeOfType<AcceptedResult>();
		}
	}
}
