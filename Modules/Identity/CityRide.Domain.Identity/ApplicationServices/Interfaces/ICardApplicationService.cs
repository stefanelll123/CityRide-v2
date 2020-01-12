using System;
using System.Threading.Tasks;

using CityRide.Entities.Identity;
using CityRide.Infrastructure;

namespace CityRide.Domain.Identity.ApplicationServices.Interfaces
{
    public interface ICardApplicationService
    {
        Task<Result> AddCard(Guid userId, Card card);

        Task<Card> GetCard(Guid userId);
    }
}
