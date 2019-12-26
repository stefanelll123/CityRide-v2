using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using CityRide.Infrastructure;
using CityRide.Ports.Web.Identity;
using CityRide.Ports.Web.Identity.Models;

namespace CityRide.WebApi.Controllers.Identity
{
    [ApiController]
    [Route("api/v1.0/register")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterPort _registerPort;

        public RegisterController(IRegisterPort registerPort)
        {
            _registerPort = registerPort;
        }

        [HttpPost]
        public async Task<Result> CreateUser([FromBody]CreateUserModel createUserModel)
        {
            return await _registerPort.CreateUser(createUserModel);
        }
    }
}
