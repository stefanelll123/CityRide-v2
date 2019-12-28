using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using EnsureThat;

using CityRide.Ports.Web.Bike;
using CityRide.Ports.Web.Bike.Models;

namespace CityRide.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpGet("position")]
        public Task<IActionResult> GetBikesByPosition([FromQuery(Name = "latitude")] double latitude, [FromQuery(Name = "longitude")] double longitude)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetBikes()
        {
            var bikes = await _bikePort.GetAllBikesAsync();

            return Ok(bikes);
        }

        [HttpPost]
        public async Task<IActionResult> AddBike([FromBody]BikeCreateModel bikeModel)
        {
            await _bikePort.AddBike(bikeModel);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBikePosition([FromRoute] Guid id, [FromBody] BikePositionModel bikePositionModel)
        {
            await _bikePort.UpdateBikePosition(id, bikePositionModel);

            return Ok();
        }

        [HttpPost("borrow/{id}")]
        public async Task<IActionResult> BorrowBike([FromRoute] Guid id)
        {
            var response = await _bikePort.Borrow(id);

            return Ok(response);
        }
    }
}

