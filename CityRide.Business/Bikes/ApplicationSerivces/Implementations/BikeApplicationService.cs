using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityRide.Business.Bikes.ApplicationSerivces.Interfaces;
using CityRide.Business.Bikes.Models;
using CityRide.Business.Repositories;
using CityRide.CrossCuttingConcern;
using CityRide.Domain.Entities;
using EnsureThat;

namespace CityRide.Business.Bikes.ApplicationSerivces.Implementations
{
    public class BikeApplicationService : IBikeApplicationService
    {
        private IBikeRepository _bikeRepository;
        private IMapper _mapper;

        public BikeApplicationService(
            IBikeRepository bikeRepository,
            IMapper mapper)
        {
            EnsureArg.IsNotNull(bikeRepository);
            EnsureArg.IsNotNull(mapper);

            _bikeRepository = bikeRepository;
            _mapper = mapper;
        }

        async Task IBikeApplicationService.AddBikeAsync(BikeModel bikeModel)
        {
            var bike = _mapper.Map<BikeModel, Bike>(bikeModel);
            await _bikeRepository.AddAsync(bike);
        }

        async Task<ICollection<BikeModel>> IBikeApplicationService.GetAllBikesAsync()
        {
            var bikes = await _bikeRepository.GetAllAsync();

            return bikes.Select(x => _mapper.Map<Bike, BikeModel>(x)).ToList();
        }
    }
}
