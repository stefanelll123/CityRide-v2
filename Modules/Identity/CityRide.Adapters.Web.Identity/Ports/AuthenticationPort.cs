using System.Threading.Tasks;
using AutoMapper;
using CityRide.Domain.Identity.ApplicationServices.Interfaces;
using CityRide.Entities.Identity.Dtos;
using CityRide.Infrastructure;
using CityRide.Ports.Web.Identity;
using CityRide.Ports.Web.Identity.Models;

namespace CityRide.Adapters.Web.Identity.Ports
{
    internal sealed class AuthenticationPort : IAuthenticationPort
    {
        private readonly IAuthenticationApplicationService _authenticationApplicationService;
        private readonly IMapper _mapper;

        public AuthenticationPort(IAuthenticationApplicationService authenticationApplicationService, IMapper mapper)
        {
            _authenticationApplicationService = authenticationApplicationService;
            _mapper = mapper;
        }

        async Task<Result> IAuthenticationPort.Login(UserAuthenticationModel userAuthenticationModel)
        {
            var userAuthentication = _mapper.Map<UserAuthenticationDto>(userAuthenticationModel);
            var result = await Result.Ok()
                                .And(async () => await _authenticationApplicationService.Login(userAuthentication))
                                .Map<AuthenticationDto, AuthenticationModel>((data) => _mapper.Map<AuthenticationModel>(data));

            return result;
        }
    }
}
