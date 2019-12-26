using System.Threading.Tasks;

using MongoDB.Driver;

using CityRide.Infrastructure;
using CityRide.Interop.DataAccess.Identity.Repositories;
using CityRide.Entities.Identity;

namespace CityRide.Adapters.DataAccess.Identity.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(DatabaseContext context)
        {
            _users = context.Users;
        }

        async Task IUserRepository.CreateUser(User user)
        {
            await _users.InsertOneAsync(user);
        }

        async Task<User> IUserRepository.GetUserBy(string email)
        {
            var users = await _users.FindAsync(x => x.Email == email);

            return users.FirstOrDefault();
        }
    }
}
