using System;

namespace HumanResourcesManager.Core.Entities
{
    public class User : Entity
	{
		public string UserName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Salt { get; set; }

        public DateTime CreationDateTime { get; set; }

        public string ChangePasswordToken { get; set; }

        public string RefreshToken { get; set; }

        public Employee Employee { get; set; }

        public Guid EmployeeId { get; set; }
    }
}
