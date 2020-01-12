using System;
using System.Threading.Tasks;

using CityRide.Entities.Identity;

namespace CityRide.Interop.DataAccess.Identity.Repositories
{
    public interface IUserRepository
    {
        Task CreateUser(User user);

        Task<User> GetUserBy(string email);

        Task<User> GetUserBy(Guid id);

        Task UpdateUser(User user);

        Task<Card> GetCard(Guid userId);
    }
}
