using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HumanResourcesManager.Core.Dto;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Core.Enums;
using HumanResourcesManager.Core.Repositories.Abstract;
using HumanResourcesManager.Infrastructure.Queries.Employee;
using Moq;
using Xunit;

namespace HumanResourcesManager.Infrastructure.Tests.Query.Handlers
{
	public class GetEmployeesQueryTests
	{
		private readonly Mock<IEmployeesRepository> repositorieMock;
		private readonly Mock<IMapper> mapperMock;
		private IEnumerable<Employee> employees;
		private IEnumerable<EmployeeDto> employeesDto;
		private readonly GetEmployeesQueryHandler getEmployees;
		private readonly GetEmployeesQueryModel model;

		public GetEmployeesQueryTests()
		{
			repositorieMock = new Mock<IEmployeesRepository>();
			mapperMock = new Mock<IMapper>();
			getEmployees = new GetEmployeesQueryHandler(repositorieMock.Object, mapperMock.Object);
			model = new GetEmployeesQueryModel();
		}

		[Fact]
		public void When_Full_List_Of_Employees_Is_Needed()
		{
			//Arrange 
			employees = new Employee[]
			{
				new Employee() { Address = "Krakow", DateOfBirth = new DateTime(1990, 1, 10), FirstName = "Tomasz", LastName = "Kowalczyk", Position = JobPositions.Developer, RoomNumber = 100},
				new Employee() { Address = "Krakow", DateOfBirth = new DateTime(1992, 1, 10), FirstName = "Daniel", LastName = "Kowalski", Position = JobPositions.Architect, RoomNumber = 101},
				new Employee() { Address = "Krakow", DateOfBirth = new DateTime(1991, 1, 10), FirstName = "Szymon", LastName = "Maj", Position = JobPositions.Tester, RoomNumber = 102},
				new Employee() { Address = "Krakow", DateOfBirth = new DateTime(1995, 1, 10), FirstName = "Aneta", LastName = "Baran", Position = JobPositions.Developer, RoomNumber = 100},
				new Employee() { Address = "Krakow", DateOfBirth = new DateTime(1989, 1, 10), FirstName = "Aleksandra", LastName = "Szewczyk", Position = JobPositions.TeamLeader, RoomNumber = 103},
			};
			employeesDto = new EmployeeDto[]
			{
				new EmployeeDto() { Address = "Krakow", DateOfBirth = new DateTime(1990, 1, 10), FirstName = "Tomasz", LastName = "Kowalczyk", Position = JobPositions.Developer, RoomNumber = 100},
				new EmployeeDto() { Address = "Krakow", DateOfBirth = new DateTime(1992, 1, 10), FirstName = "Daniel", LastName = "Kowalski", Position = JobPositions.Architect, RoomNumber = 101},
				new EmployeeDto() { Address = "Krakow", DateOfBirth = new DateTime(1991, 1, 10), FirstName = "Szymon", LastName = "Maj", Position = JobPositions.Tester, RoomNumber = 102},
				new EmployeeDto() { Address = "Krakow", DateOfBirth = new DateTime(1995, 1, 10), FirstName = "Aneta", LastName = "Baran", Position = JobPositions.Developer, RoomNumber = 100},
				new EmployeeDto() { Address = "Krakow", DateOfBirth = new DateTime(1989, 1, 10), FirstName = "Aleksandra", LastName = "Szewczyk", Position = JobPositions.TeamLeader, RoomNumber = 103},
			};
			repositorieMock.Setup(x => x.GetEmployesAsync()).ReturnsAsync(employees);
			mapperMock.Setup(s => s.Map<IEnumerable<EmployeeDto>>(It.IsAny<IEnumerable<Employee>>())).Returns(employeesDto);
			
			//Act
			var employeesList = getEmployees.Handle(model, default);

			//Assert
			Assert.Equal(employeesList.Result.Count(), employeesDto.Count());
		}

		[Fact]
		public void When_Empty_List_Of_Employees_Is_Needed()
		{
			//Arrange 
			employees = new Employee[0];
			employeesDto = new EmployeeDto[0];
			repositorieMock.Setup(x => x.GetEmployesAsync()).ReturnsAsync(employees);
			mapperMock.Setup(s => s.Map<IEnumerable<EmployeeDto>>(It.IsAny<IEnumerable<Employee>>())).Returns(employeesDto);

			//Act
			var employeesList = getEmployees.Handle(model, default);

			//Assert
			Assert.Equal(employeesList.Result.Count(), employeesDto.Count());
		}
	}
}
