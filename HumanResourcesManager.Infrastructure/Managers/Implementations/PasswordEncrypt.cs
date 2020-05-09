using System.Security.Cryptography;
using System.Text;
using HumanResourcesManager.Infrastructure.Managers.Abstract;

namespace HumanResourcesManager.Infrastructure.Managers.Implementations
{
	public class PasswordEncrypt : IPasswordEncrypt
	{
		public void PasswordHash(string password, out byte[] salt, out byte[] passwordHash)
		{
			using var hmac = new HMACSHA512();
			salt = hmac.Key;
			passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
		}

		public bool VerificationPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using var hmac = new HMACSHA512(passwordSalt);
			var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

			for (int i = 0; i < computedHash.Length; i++)
			{
				if (computedHash[i] != passwordHash[i])
				{
					return false;
				}
			}

			return true;
		}
	}
}