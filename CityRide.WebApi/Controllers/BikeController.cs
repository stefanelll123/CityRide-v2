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
        public async Task<IActionResult> GetBikesByPosition([FromQuery(Name = "latitude")] double latitude, [FromQuery(Name = "longitude")] double longitude)
        {
            return Ok(await _bikePort.GetBikesByPosition(latitude, longitude));
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
            var userId = GetRequestUserId();
            if (userId == null)
            {
                return Unauthorized();
            }
            var response = await _bikePort.Borrow(id, userId.Value);

            return Ok(response);
        }

        [HttpPost("return/{id}")]
        public async Task<IActionResult> ReturnBike([FromRoute] Guid id)
        {
            var response = await _bikePort.Return(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("borrow/user")]
        public async Task<IActionResult> GetCurrentUserBorrowBike()
        {
            var userId = GetRequestUserId();
            if(userId == null)
            {
                return Unauthorized();
            }

            var userBorrowModel = await _bikePort.GetBikeBorrowedByUser(userId.Value);
            if(userBorrowModel == null)
            {
                return NotFound();
            }

            return Ok(userBorrowModel);
        }

        [HttpGet("borrow/user/history")]
        public async Task<IActionResult> GetUserBorrowHistory()
        {
            var userId = GetRequestUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var userBorrowModelList = await _bikePort.GetUserBorrowHistory(userId.Value);
            return Ok(userBorrowModelList);
        }

        private Guid? GetRequestUserId()
        {
            var userId = new Guid(HttpContext.User.FindFirst("UserId").Value);

            return userId;
        }
    }
}

