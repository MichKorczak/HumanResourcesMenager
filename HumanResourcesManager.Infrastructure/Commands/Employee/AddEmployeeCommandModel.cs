using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace HumanResourcesManager.Infrastructure.Commands.Employee
{
	public class AddEmployeeCommandModel : IRequest
	{
		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public DateTime DateOfBirth { get; set; }

		[Required]
		public string Address { get; set; }
	}
}
