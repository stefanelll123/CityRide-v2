using System.Threading.Tasks;

using EnsureThat;
using MongoDB.Driver;

using CityRide.Interop.DataAccess.Bike.Repositories;
using CityRide.Infrastructure;
using System.Linq;

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

        public async Task<double> GetValue()
        {
            var pricesList = await _prices.Find(x => x.StartDate != null)
                .SortByDescending(x => x.StartDate).ToListAsync();
            var currentPrice = pricesList.FirstOrDefault();
            double value = -1;

            if (currentPrice != null)
            {
                value = currentPrice.Value;
            }

            return value;
        }
    }
}
