﻿using System.Threading.Tasks;
using HumanResourcesManager.Core.DbDomain.Abstract;
using HumanResourcesManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesManager.Core.DbDomain.Implementation
{
	public class HumanResourceContext : DbContext, IHumanResourceContext
	{
		public HumanResourceContext(DbContextOptions<HumanResourceContext> options) : base(options)
		{
		}

		public DbSet<Employee> Employees { get; set; }

		public Task<bool> SaveAsync() => this.SaveAsync();
	}
}
