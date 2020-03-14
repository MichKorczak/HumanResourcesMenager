using HumanResourcesMenager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesMenager.Core.DBDomain.Abstract
{
	public interface IUserContext
	{
		DbSet<Employe> Employes { get; set; }
	}
}
