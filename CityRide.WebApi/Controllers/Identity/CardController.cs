using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using CityRide.Ports.Web.Identity;
using CityRide.Ports.Web.Identity.Models;

namespace CityRide.WebApi.Controllers.Identity
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/v1.0/cards")]
    [ApiController]
    public class CardController : BaseController
    {
        private readonly ICardPort _cardPort;

        public CardController(ICardPort cardPort)
        {
            _cardPort = cardPort;
        }

        [HttpPost()]
        public async Task<IActionResult> AddCard([FromBody]CardCreateModel cardCreateModel)
        {
            var userId = GetRequestUserId();
            if(userId == null)
            {
                return Unauthorized();
            }

            var result = await _cardPort.AddCard(userId.Value, cardCreateModel);
            if (result.HasErrors)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}