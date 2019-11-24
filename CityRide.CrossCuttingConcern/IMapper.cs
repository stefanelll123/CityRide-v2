namespace CityRide.CrossCuttingConcern
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
