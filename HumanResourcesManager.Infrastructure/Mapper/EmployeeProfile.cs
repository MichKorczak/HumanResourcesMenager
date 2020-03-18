using AutoMapper;
using HumanResourcesManager.Core.Dto;
using HumanResourcesManager.Core.Entities;

namespace HumanResourcesManager.Infrastructure.Mapper
{
	class EmployeeProfile : Profile
	{
		public EmployeeProfile()
		{
			CreateMap<Employee, EmployeeDto>();
		}
	}
}
