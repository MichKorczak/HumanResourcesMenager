using System.ComponentModel.DataAnnotations;
using HumanResourcesManager.Core.Dto;
using MediatR;

namespace HumanResourcesManager.Infrastructure.Queries.User
{
	public class LoginQueryModel : IRequest<TokenModel>
	{
		[Required]
		public string Login { get; set; }

		[Required]
		[MinLength(6)]
		public string Password { get; set; }
	}
}