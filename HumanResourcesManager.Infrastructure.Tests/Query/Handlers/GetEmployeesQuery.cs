using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Core.Repositories.Abstract;
using HumanResourcesManager.Infrastructure.Queries.Employee;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Moq;
using Xunit;

namespace HumanResourcesManager.Infrastructure.Tests.Query.Handlers
{
	public class GetEmployeesQuery
	{
		private readonly GetEmployeesQueryHandler mock;

		public GetEmployeesQuery()
		{
			var repositoriesMock = new Mock<IEmployeesRepository>();
			var mapperMock = new Mock<IMapper>();

			mock = new GetEmployeesQueryHandler(repositoriesMock.Object, mapperMock.Object);
		}

		[Fact]
		public void When_Full_List_Of_Employees_Is_Needed()
		{
			//Arrange 
			
			//Act
			
			//Assert
		}
	}
}
