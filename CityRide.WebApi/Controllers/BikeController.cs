using Microsoft.AspNetCore.Mvc;
using EnsureThat;
using System.Threading.Tasks;
using CityRide.Business.Bikes.ApplicationSerivces.Interfaces;
using CityRide.Business.Bikes.Models;

namespace CityRide.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1.0/bikes")]
    public class BikeController : ControllerBase
    {
        private IBikeApplicationService _bikeApplicationService;

        public BikeController(IBikeApplicationService bikeApplicationService)
        {
            EnsureArg.IsNotNull(bikeApplicationService);

            _bikeApplicationService = bikeApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBike([FromBody]BikeModel bikeModel)
        {
            await _bikeApplicationService.AddBikeAsync(bikeModel);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetBikes()
        {
            var bikes = await _bikeApplicationService.GetAllBikesAsync();

            return Ok(bikes);
        }
    }
}

