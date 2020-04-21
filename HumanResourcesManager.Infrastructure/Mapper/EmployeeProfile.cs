using System.Linq;
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
			CreateMap<Employee, EmployeeDto>()
				.ForMember(dest 
					=> dest.Position, opt 
						=> opt.MapFrom(src => src.Positions == null ? "Empty" : src.Positions.First().Position.PositionName));
			CreateMap<AddEmployeeCommandModel, Employee>();
		}
	}
}
