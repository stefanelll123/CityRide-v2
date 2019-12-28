using System.Threading.Tasks;
using CityRide.Infrastructure;
using CityRide.Ports.Web.Identity;
using CityRide.Ports.Web.Identity.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityRide.WebApi.Controllers.Identity
{
    [ApiController]
    [Route("api/v1.0/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationPort _authenticationPort;

        public AuthenticationController(IAuthenticationPort authenticationPort)
        {
            _authenticationPort = authenticationPort;
        }

        [HttpPost]
        public async Task<Result> Login(UserAuthenticationModel userAuthenticationModel)
        {
            return await _authenticationPort.Login(userAuthenticationModel);
        }
    }
}
