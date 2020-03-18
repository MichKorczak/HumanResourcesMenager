using System;

namespace HumanResourcesManager.Core.Entities
{
	public abstract class Entity
	{
		public Guid Id { get; protected set; }
	}
}
