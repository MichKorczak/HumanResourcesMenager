﻿using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Core.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesManager.Core.DbDomain
{
	public class HumanResourceContext : DbContext, IUnitOfWork
	{
		public HumanResourceContext() { }

		public HumanResourceContext(DbContextOptions<HumanResourceContext> options) 
			: base(options)
		{
		}

		public DbSet<Employee> Employees { get; set; }
	}
}
