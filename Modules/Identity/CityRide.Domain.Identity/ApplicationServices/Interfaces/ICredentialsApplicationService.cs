using CityRide.Entities.Identity;
using System.Threading.Tasks;
using CityRide.Infrastructure;

namespace CityRide.Domain.Identity.ApplicationServices.Interfaces
{
    public interface ICredentialsApplicationService
    {
        Task<Result> CreateUser(User user);
    }
}
