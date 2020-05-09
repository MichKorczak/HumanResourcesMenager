using System;

namespace HumanResourcesManager.Core.Exceptions
{
	public class ManagerException : Exception
	{
		public ManagerException()
		{
		}

		public ManagerException(string message)
			: base(message)
		{
		}

		public ManagerException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}