using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HumanResourcesManager.Core.Dto;
using HumanResourcesManager.Core.Settings;
using HumanResourcesManager.Infrastructure.Managers.Abstract;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HumanResourcesManager.Infrastructure.Managers.Implementations
{
	public class TokenManager : ITokenManager
	{
		private readonly JwtSettings options;

		public TokenManager(IOptions<JwtSettings> options)
		{
			this.options = options.Value;
		}

		public TokenModel GetToken(Guid userId, string email, string role)
		{
			var date = DateTime.UtcNow;

			role = string.IsNullOrEmpty(role) ? "None" : role;

			var claims = new Claim[]
			{
				new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()), 
				new Claim(JwtRegisteredClaimNames.Sub, email), 
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), 
				new Claim(ClaimTypes.Role, role)
			};

			var signCredential = new SigningCredentials(
				new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey)), 
				SecurityAlgorithms.HmacSha256);

			var expires = date.AddMinutes(options.ExpiresMinutes);

			var jwt = new JwtSecurityToken(
				issuer: options.Issuer,
				claims: claims,
				notBefore: date,
				expires: expires,
				signingCredentials: signCredential);

			var token = new JwtSecurityTokenHandler().WriteToken(jwt);
			
			return new TokenModel(userId, token, expires, role); 
		}
	}
}