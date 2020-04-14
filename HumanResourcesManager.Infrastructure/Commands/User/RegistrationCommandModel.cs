﻿using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace HumanResourcesManager.Infrastructure.Commands.User
{
	public class RegistrationCommandModel : IRequest
	{
		[Required]
		public string UserName { get; set; }

		[Required]
		public string Email { get; set; }

		[Required] 
		public string Password { get; set; }

		[Required] 
		public Guid EmployeeId { get; set; }
	}
}