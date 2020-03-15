using HumanResourcesManager.Core.Abstract;
using System;

namespace HumanResourcesManager.Core.Entities
{
    public class User : Entity
	{
        public string UserName { get; protected set; }

        public string Email { get; protected set; }

        public string PasswordHash { get; protected set; }

        public string Salt { get; protected set; }

        public DateTime CreationDateTime { get; protected set; }

        public string ChangePasswordToken { get; protected set; }

        public string RefreshToken { get; protected set; }
    }
}
