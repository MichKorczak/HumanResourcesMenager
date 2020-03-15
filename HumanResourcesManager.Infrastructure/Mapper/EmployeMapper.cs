using AutoMapper;
using HumanResourcesManager.Core.Dto;
using HumanResourcesManager.Core.Entities;

namespace HumanResourcesManager.Infrastructure.Mapper
{
	class EmployeMapper : Profile
	{
		public EmployeMapper()
		{
			CreateMap<Employee, EmployeeDto>();
		}
	}
}
