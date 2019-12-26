using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using CityRide.Infrastructure;
using CityRide.Ports.Web.Identity;
using CityRide.Ports.Web.Identity.Models;

namespace CityRide.WebApi.Controllers.Identity
{
    [ApiController]
    [Route("api/v1.0/credentials")]
    public class CredentialsController : ControllerBase
    {
        private readonly IIdentityPort _identityPort;

        public CredentialsController(IIdentityPort identityPort)
        {
            _identityPort = identityPort;
        }

        [HttpPost]
        public async Task<Result> CreateUser([FromBody]CreateUserModel createUserModel)
        {
            return await _identityPort.CreateUser(createUserModel);
        }
    }
}
