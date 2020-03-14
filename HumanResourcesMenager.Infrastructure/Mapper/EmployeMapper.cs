using AutoMapper;
using HumanResourcesMenager.Core.DTO;
using HumanResourcesMenager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesMenager.Infrastructure.Mapper
{
	class EmployeMapper : Profile
	{
		public EmployeMapper()
		{
			CreateMap<Employe, EmployeDTO>();
		}
	}
}
