using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using HumanResourcesManager.Api.Bus;
using HumanResourcesManager.Api.Controllers;
using HumanResourcesManager.Core.Dto;
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
		public async Task When_Request_Came_Then_Return_Ok(EmployeeDto[] employees)
		{
			// Arrange
			busMock.Setup(x => x.SendAsync(new GetEmployeesQueryModel(It.IsAny<IEnumerable<EmployeeDto>>()), default)).ReturnsAsync(employees);
			OkObjectResult okObject = new OkObjectResult(employees);

			// Act
			var response = (await sut.Get());

			// Assert
			response.Should().BeEquivalentTo<OkObjectResult>(okObject);
		}
	}
}
