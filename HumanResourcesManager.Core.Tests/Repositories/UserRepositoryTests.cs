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
	public class UserRepositoryTests
	{
		private readonly DbContextOptions<HumanResourceContext> opt;
		private readonly HumanResourceContext context;
		private readonly UserRepository sut;
		private readonly Fixture fixture;

		public UserRepositoryTests()
		{
			opt = new DbContextOptionsBuilder<HumanResourceContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
			context = new HumanResourceContext(opt);
			sut = new UserRepository(context);
			fixture = new Fixture();
		}

		[Fact]
		public async Task When_Registration_Async_Then_Add_User_To_Context()
		{
			// Arrange
			var user = fixture.Build<User>().Without(x => x.Employee).Create();

			// Act
			await sut.RegistrationAsync(user);

			// Assert
			var result = context.Users.Local.FirstOrDefault(x => x.Id == user.Id);
			result.Should().NotBeNull();
			result.Should().Be(user);
		}
	}
}