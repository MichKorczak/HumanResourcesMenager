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

		[Theory]
		[AutoData]
		public async Task When_Request_Came_Then_Return_Ok_Result_With_List(EmployeeDto[] employees)
		{
			// Arrange
			busMock.Setup(x => x.SendAsync(It.IsAny<GetEmployeesQueryModel>(), default)).ReturnsAsync(employees);
			OkObjectResult okObject = new OkObjectResult(employees);

			// Act
			var response = (await sut.Get());

			// Assert
			response.Should().BeEquivalentTo<OkObjectResult>(okObject);
		}

		[Theory]
		[AutoData]
		public async Task When_Request_Came_Then_Send_Command_To_Add_Employee(AddEmployeeCommandModel model, Guid id)
		{
			// Arrange
			OkObjectResult okResult = new OkObjectResult(id);
			busMock.Setup(x => x.SendAsync(It.IsAny<AddEmployeeCommandModel>(), default)).ReturnsAsync(id);

			// Act
			var response = (await sut.Post(model));

			// Assert
			response.Should().BeEquivalentTo<OkObjectResult>(okResult);
		}
	}
}
