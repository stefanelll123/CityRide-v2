using System.Net;
using System.Threading.Tasks;

using CityRide.Domain.Identity.ApplicationServices.Interfaces;
using CityRide.Domain.Identity.DomainServices.Interfaces;
using CityRide.Entities.Identity;
using CityRide.Infrastructure;
using CityRide.Interop.DataAccess.Identity.Repositories;

namespace CityRide.Domain.Identity.ApplicationServices.Implementations
{
    internal sealed class CredentialsApplicationService : ICredentialsApplicationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public CredentialsApplicationService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        async Task<Result> ICredentialsApplicationService.CreateUser(User user)
        {
            var databaseUser = await _userRepository.GetUserBy(user.Email);
            if (databaseUser != null)
            {
                return Result.Error(HttpStatusCode.BadRequest, string.Format(Resource.UserAlreadyExists, user.Email));
            }

            var saveUser = User.Create(user.FullName, user.Email, _passwordHasher.Hash(user.Password));
            await _userRepository.CreateUser(saveUser);

            return Result.Ok(HttpStatusCode.Created);
        }
    }
}
