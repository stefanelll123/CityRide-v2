using System.Threading.Tasks;

using AutoMapper;

using CityRide.Domain.Identity.ApplicationServices.Interfaces;
using CityRide.Entities.Identity;
using CityRide.Infrastructure;
using CityRide.Ports.Web.Identity;
using CityRide.Ports.Web.Identity.Models;

namespace CityRide.Adapters.Web.Identity
{
    internal sealed class IdentityPort : IIdentityPort
    {
        private readonly ICredentialsApplicationService _credentialsApplicationService;
        private readonly IMapper _mapper;

        public IdentityPort(ICredentialsApplicationService credentialsApplicationService, IMapper mapper)
        {
            _credentialsApplicationService = credentialsApplicationService;
            _mapper = mapper;
        }

        async Task<Result> IIdentityPort.CreateUser(CreateUserModel createUserModel)
        {
            var user = _mapper.Map<User>(createUserModel);

            return await _credentialsApplicationService.CreateUser(user);
        }
    }
}
