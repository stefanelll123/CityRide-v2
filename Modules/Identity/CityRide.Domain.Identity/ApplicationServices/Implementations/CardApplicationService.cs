using System;
using System.Threading.Tasks;
using CityRide.Domain.Identity.ApplicationServices.Interfaces;
using CityRide.Entities.Identity;
using CityRide.Infrastructure;
using CityRide.Interop.DataAccess.Identity.Repositories;

namespace CityRide.Domain.Identity.ApplicationServices.Implementations
{
    public sealed class CardApplicationService : ICardApplicationService
    {
        private readonly IUserRepository _userRepository;

        public CardApplicationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        async Task<Result> ICardApplicationService.AddCard(Guid userId, Card card)
        {
            var user = await _userRepository.GetUserBy(userId);
            if(user == null)
            {
                return Result.Error(System.Net.HttpStatusCode.NotFound, "User not found");
            }

            user.AddCard(card);
            await _userRepository.UpdateUser(user);

            return Result.Ok();
        }

        async Task<Card> ICardApplicationService.GetCard(Guid userId)
        {
            return await _userRepository.GetCard(userId);
        }
    }
}
