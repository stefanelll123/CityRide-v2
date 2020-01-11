using System.Threading.Tasks;

using EnsureThat;
using MongoDB.Driver;

using CityRide.Interop.DataAccess.Bike.Repositories;
using CityRide.Infrastructure;
using System.Linq;
using System;
using CityRide.Entities.Price;

namespace CityRide.Adapters.DataAccess.Bike.Repositories
{
    public sealed class PriceRepository : IPriceRepository
    {
        private readonly IMongoCollection<Entities.Price.Price> _prices;

        public PriceRepository(DatabaseContext databaseContext)
        {
            EnsureArg.IsNotNull(databaseContext);

            _prices = databaseContext.Price;
        }

        async Task<double> IPriceRepository.GetValue()
        {
            var pricesList = await _prices.Find(x => true)
                .SortByDescending(x => x.StartDate).ToListAsync();
            var currentPrice = pricesList.FirstOrDefault();
            double value = -1;

            if (currentPrice != null)
            {
                value = currentPrice.Value;
            }

            return value;
        }

        Price IPriceRepository.GetPriceBy(Guid id)
        {
            return _prices.Find(x => x.Id == id).FirstOrDefault();
        }

        Price IPriceRepository.GetLastPrice()
        {
            return _prices.Find(x => true)
                .SortByDescending(x => x.StartDate).FirstOrDefault();
        }
    }
}
