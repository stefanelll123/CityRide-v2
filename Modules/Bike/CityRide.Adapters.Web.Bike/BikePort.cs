
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CityRide.Domain.Bike.ApplicationServices.Interfaces;
using CityRide.Ports.Web.Bike;
using CityRide.Ports.Web.Bike.Models;
using EnsureThat;

namespace CityRide.Adapters.Web.Bike
{
    public sealed class BikePort : IBikePort
    {
        private readonly IBikeApplicationService _bikeApplicationService;
        private readonly IMapper _mapper;

        public BikePort(IBikeApplicationService bikeApplicationService, IMapper mapper)
        {
            EnsureArg.IsNotNull(bikeApplicationService);
            EnsureArg.IsNotNull(mapper);

            _bikeApplicationService = bikeApplicationService;
            _mapper = mapper;
        }

        async Task IBikePort.AddBike(BikeModel bikeModel)
        {
            var bike = _mapper.Map<Entities.Bike.Bike>(bikeModel);
            await _bikeApplicationService.AddBikeAsync(bike);
        }

        async Task<ICollection<BikeModel>> IBikePort.GetAllBikesAsync()
        {
            var bikes = await _bikeApplicationService.GetAllBikesAsync();

            return _mapper.Map<ICollection<BikeModel>>(bikes);
        }
    }
}
