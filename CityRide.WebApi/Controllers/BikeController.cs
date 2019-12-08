using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnsureThat;

using CityRide.Ports.Web.Bike;
using CityRide.Ports.Web.Bike.Models;

namespace CityRide.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1.0/bikes")]
    public class BikeController : ControllerBase
    {
        private readonly IBikePort _bikePort;

        public BikeController(IBikePort bikePort)
        {
            EnsureArg.IsNotNull(bikePort);

            _bikePort = bikePort;
        }

        [HttpPost]
        public async Task<IActionResult> AddBike([FromBody]BikeModel bikeModel)
        {
            await _bikePort.AddBike(bikeModel);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetBikes()
        {
            var bikes = await _bikePort.GetAllBikesAsync();

            return Ok(bikes);
        }
    }
}

