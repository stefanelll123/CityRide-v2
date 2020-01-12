using Microsoft.AspNetCore.Mvc;
using System;

namespace CityRide.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected Guid? GetRequestUserId()
        {
            var userId = new Guid(HttpContext.User.FindFirst("UserId").Value);

            return userId;
        }
    }
}
