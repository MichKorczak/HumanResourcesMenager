using HumanResourcesMenager.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanResourcesMenager.Infrastructure.Services.Abstract
{
	public interface IGetEmployeesService
	{
		Task<IList<EmployeDTO>> GetEmployesAsync(); 
	}
}
