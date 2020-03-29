using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesManager.Infrastructure.Interfaces
{
	public interface IMapper
	{
		TDestination Map<TSource, TDestination>(TSource source);

		IEnumerable<TDestination> MapCollection<TSource, TDestination>(IEnumerable<TSource> source);
	}
}
