using AutoMapper;
using CityRide.Entities.Bike.Dtos;
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
        private readonly IUserPort _userPort;

        public IdentityInterop(ICardPort cardPort, IUserPort userPort, IMapper mapper)
        {
            _cardPort = cardPort;
            _userPort = userPort;
            _mapper = mapper;
        }

        async Task<CardDto> IIdentityInterop.GetCardEndNumbers(Guid userId)
        {
            var result = await _cardPort.GetCardLastNumbers(userId);

            return _mapper.Map<CardDto>(result);
        }

        async Task<UserDto> IIdentityInterop.GetUserInfo(Guid userId)
        {
            var user = await _userPort.GetUserBy(userId);

            return _mapper.Map<UserDto>(user);
        }
    }
}
