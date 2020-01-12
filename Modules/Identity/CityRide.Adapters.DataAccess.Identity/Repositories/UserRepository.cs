using System.Threading.Tasks;

using MongoDB.Driver;

using CityRide.Infrastructure;
using CityRide.Interop.DataAccess.Identity.Repositories;
using CityRide.Entities.Identity;
using System;

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

        async Task<Card> IUserRepository.GetCard(Guid userId)
        {
            var users = await _users.FindAsync(x => x.Id == userId);

            return users.FirstOrDefault().Card;
        }

        async Task<User> IUserRepository.GetUserBy(string email)
        {
            var users = await _users.FindAsync(x => x.Email == email);

            return users.FirstOrDefault();
        }

        async Task<User> IUserRepository.GetUserBy(Guid id)
        {
            var users = await _users.FindAsync(x => x.Id == id);

            return users.FirstOrDefault();
        }

        async Task IUserRepository.UpdateUser(User user)
        {
            var filter = Builders<User>.Filter.Eq(s => s.Id, user.Id);
            await _users.ReplaceOneAsync(filter, user);
        }
    }
}
