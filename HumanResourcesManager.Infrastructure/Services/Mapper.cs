using System;
using System.Collections.Generic;
using System.Text;
using HumanResourcesManager.Infrastructure.Interfaces;

namespace HumanResourcesManager.Infrastructure.Services
{
	public class Mapper : IMapper
	{
		private readonly AutoMapper.IMapper _mapper;

		public Mapper(AutoMapper.IMapper mapper)
		{
			_mapper = mapper;
		}

		public TDestination Map<TSource, TDestination>(TSource source)
		{
			return _mapper.Map<TSource, TDestination>(source);
		}

		public IEnumerable<TDestination> MapCollection<TSource, TDestination>(IEnumerable<TSource> source)
		{
			return _mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
		}
	}
}
