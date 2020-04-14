namespace HumanResourcesManager.Infrastructure.Managers.Abstract
{
	public interface IPasswordEncrypt
	{
		void PasswordHash(string password, out byte[] salt, out byte[] hashPassword);

		bool VerificationPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
	}
}