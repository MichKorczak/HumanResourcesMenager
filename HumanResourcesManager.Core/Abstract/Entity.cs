using System;

namespace HumanResourcesManager.Core.Abstract
{
	public abstract class Entity
	{
		public Guid Id { get; protected set; }
	}
}
