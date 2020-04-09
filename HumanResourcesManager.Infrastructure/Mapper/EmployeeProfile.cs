using AutoMapper;
using HumanResourcesManager.Core.Dto;
using HumanResourcesManager.Core.Entities;
using HumanResourcesManager.Infrastructure.Commands.Employee;

namespace HumanResourcesManager.Infrastructure.Mapper
{
	public class EmployeeProfile : Profile
	{
		public EmployeeProfile()
		{
			CreateMap<Employee, EmployeeDto>();
			CreateMap<AddEmployeeCommandModel, Employee>();
		}
	}
}
