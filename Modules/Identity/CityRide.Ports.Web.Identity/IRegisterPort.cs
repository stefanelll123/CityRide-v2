using System.Threading.Tasks;

using CityRide.Infrastructure;
using CityRide.Ports.Web.Identity.Models;

namespace CityRide.Ports.Web.Identity
{
    public interface IRegisterPort
    {
        Task<Result> CreateUser(CreateUserModel createUserModel);
    }
}
