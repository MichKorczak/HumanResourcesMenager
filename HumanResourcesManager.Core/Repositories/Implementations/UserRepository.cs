﻿using System.Threading.Tasks;
using HumanResourcesManager.Core.DbDomain;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Core.Repositories.Abstract;

namespace HumanResourcesManager.Core.Repositories.Implementations
{
	public class UserRepository : Repository, IUserRepository
	{
		private readonly HumanResourceContext context;

		public UserRepository(HumanResourceContext context) : base(context)
		{
			this.context = context;
		}

		public async Task RegistrationAsync(User user) => await context.Users.AddAsync(user);
	}
}