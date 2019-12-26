using System.Net;
using System.Threading.Tasks;

using CityRide.Domain.Identity.ApplicationServices.Interfaces;
using CityRide.Entities.Identity;
using CityRide.Infrastructure;
using CityRide.Interop.DataAccess.Identity.Repositories;

namespace CityRide.Domain.Identity.ApplicationServices.Implementations
{
    internal sealed class CredentialsApplicationService : ICredentialsApplicationService
    {
        private readonly IUserRepository _userRepository;

        public CredentialsApplicationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        async Task<Result> ICredentialsApplicationService.CreateUser(User user)
        {
            var databaseUser = await _userRepository.GetUserBy(user.Email);
            if (databaseUser != null)
            {
                return Result.Error(HttpStatusCode.BadRequest, string.Format(Resource.UserAlreadyExists, user.Email));
            }

            await _userRepository.CreateUser(user);

            return Result.Ok(HttpStatusCode.Created);
        }
    }
}
