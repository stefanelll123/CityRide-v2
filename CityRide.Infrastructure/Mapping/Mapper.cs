using CityRide.CrossCuttingConcern;
using EnsureThat;

namespace CityRide.Infrastructure.Mapping
{
    public class Mapper : IMapper
    {
        private AutoMapper.IMapper _mapper;

        public Mapper(AutoMapper.IMapper mapper)
        {
            EnsureArg.IsNotNull(mapper);

            _mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
    }
}
