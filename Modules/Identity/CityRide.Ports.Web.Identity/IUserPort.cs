using System;
using System.Threading.Tasks;

namespace CityRide.Ports.Web.Identity
{
    public interface IUserPort
    {
        Task<UserModel> GetUserBy(Guid userId);
    }
}
