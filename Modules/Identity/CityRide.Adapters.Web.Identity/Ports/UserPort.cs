using AutoMapper;
using CityRide.Domain.Identity.ApplicationServices.Interfaces;
using CityRide.Ports.Web.Identity;
using System;
using System.Threading.Tasks;

namespace CityRide.Adapters.Web.Identity.Ports
{
    public sealed class UserPort : IUserPort
    {
        private readonly IAuthenticationApplicationService _authenticationApplicationService;
        private readonly IMapper _mapper;

        public UserPort(IAuthenticationApplicationService authenticationApplicationService, IMapper mapper)
        {
            _authenticationApplicationService = authenticationApplicationService;
            _mapper = mapper;
        }

        async Task<UserModel> IUserPort.GetUserBy(Guid userId)
        {
            var user = await _authenticationApplicationService.GetUserBy(userId);

            return _mapper.Map<UserModel>(user);
        }
    }
}
