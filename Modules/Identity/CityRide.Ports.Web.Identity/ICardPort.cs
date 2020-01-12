using System;
using System.Threading.Tasks;

using CityRide.Infrastructure;
using CityRide.Ports.Web.Identity.Models;

namespace CityRide.Ports.Web.Identity
{
    public interface ICardPort
    {
        Task<Result> AddCard(Guid userId, CardCreateModel cardCreateModel);

        Task<CardModel> GetCardLastNumbers(Guid userId);
    }
}
