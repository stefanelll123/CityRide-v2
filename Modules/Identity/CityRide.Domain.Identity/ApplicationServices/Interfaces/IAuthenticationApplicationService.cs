using System.Threading.Tasks;
using CityRide.Entities.Identity.Dtos;
using CityRide.Infrastructure;

namespace CityRide.Domain.Identity.ApplicationServices.Interfaces
{
    public interface IAuthenticationApplicationService
    {
        Task<Result> Login(UserAuthenticationDto userAuthenticationDto);
    }
}
