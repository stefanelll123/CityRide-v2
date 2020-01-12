using System;
using System.Threading.Tasks;

using AutoMapper;

using CityRide.Domain.Identity.ApplicationServices.Interfaces;
using CityRide.Entities.Identity;
using CityRide.Infrastructure;
using CityRide.Ports.Web.Identity;
using CityRide.Ports.Web.Identity.Models;

namespace CityRide.Adapters.Web.Identity.Ports
{
    public sealed class CardPort : ICardPort
    {
        private readonly ICardApplicationService _cardApplicationService;
        private readonly IMapper _mapper;

        public CardPort(ICardApplicationService cardApplicationService, IMapper mapper)
        {
            _cardApplicationService = cardApplicationService;
            _mapper = mapper;
        }

        Task<Result> ICardPort.AddCard(Guid userId, CardCreateModel cardCreateModel)
        {
            var card = _mapper.Map<Card>(cardCreateModel);

            return _cardApplicationService.AddCard(userId, card);
        }

        async Task<CardModel> ICardPort.GetCardLastNumbers(Guid userId)
        {
            var card = await _cardApplicationService.GetCard(userId);

            return _mapper.Map<CardModel>(card);
        }
    }
}
