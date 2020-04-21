using System;

namespace HumanResourcesManager.Core.Entities
{
    public class User : Entity
	{
		public User(string userName, string email, DateTime creationDateTime, byte[] salt, byte[] passwordHash, Guid employeeId, string mainRole)
		{
			UserName = userName;
			Email = email;
			CreationDateTime = creationDateTime;
			Salt = salt;
			PasswordHash = passwordHash;
			EmployeeId = employeeId;
			MainRole = mainRole;
		}
        
		public string UserName { get; private set; }

        public string Email { get; private set; }

        public byte[] PasswordHash { get; private set; }

        public byte[] Salt { get; private set; }

        public DateTime CreationDateTime { get; private set; }

        public string ChangePasswordToken { get; set; }

		public string MainRole { get; set; }

		public string RefreshToken { get; set; }

        public Employee Employee { get; set; }

        public Guid EmployeeId { get; private set; }
    }
}
