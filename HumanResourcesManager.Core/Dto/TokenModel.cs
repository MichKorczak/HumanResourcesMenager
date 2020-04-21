using System;

namespace HumanResourcesManager.Core.Dto
{
	public class TokenModel
	{
		public TokenModel(Guid UserId, string token, DateTime expireTime, string role)
		{
			this.UserId = UserId;
			Token = token;
			ExpireTime = expireTime;
			Role = role;
		}

		public Guid UserId { get; protected set; }

		public string Token { get; protected set; }

		public DateTime ExpireTime { get; protected set; }

		public string Role { get; protected set; }
	}
}