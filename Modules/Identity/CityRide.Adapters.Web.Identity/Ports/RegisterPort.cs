using System.Threading.Tasks;
using AutoMapper;
using CityRide.Domain.Identity.ApplicationServices.Interfaces;
using CityRide.Entities.Identity;
using CityRide.Infrastructure;
using CityRide.Ports.Web.Identity;
using CityRide.Ports.Web.Identity.Models;

namespace CityRide.Adapters.Web.Identity.Ports
{
    internal sealed class RegisterPort : IRegisterPort
    {
        private readonly ICredentialsApplicationService _credentialsApplicationService;
        private readonly IMapper _mapper;

        public RegisterPort(ICredentialsApplicationService credentialsApplicationService, IMapper mapper)
        {
            _credentialsApplicationService = credentialsApplicationService;
            _mapper = mapper;
        }

        async Task<Result> IRegisterPort.CreateUser(CreateUserModel createUserModel)
        {
            var user = _mapper.Map<User>(createUserModel);

            return await _credentialsApplicationService.CreateUser(user);
        }
    }
}
