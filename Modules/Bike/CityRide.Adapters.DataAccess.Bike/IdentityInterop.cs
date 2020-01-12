using AutoMapper;
using CityRide.Entities.Identity.Dtos;
using CityRide.Interop.Identity.Bike;
using CityRide.Ports.Web.Identity;
using System;
using System.Threading.Tasks;

namespace CityRide.Adapters.DataAccess.Bike
{
    internal sealed class IdentityInterop : IIdentityInterop
    {
        private readonly ICardPort _cardPort;
        private readonly IMapper _mapper;

        public IdentityInterop(ICardPort cardPort, IMapper mapper)
        {
            _cardPort = cardPort;
            _mapper = mapper;
        }

        async Task<CardDto> IIdentityInterop.GetCardEndNumbers(Guid userId)
        {
            var result = await _cardPort.GetCardLastNumbers(userId);

            return _mapper.Map<CardDto>(result);
        }
    }
}
