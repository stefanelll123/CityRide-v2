using System.Threading.Tasks;

using EnsureThat;
using MongoDB.Driver;

using CityRide.Interop.DataAccess.Bike.Repositories;
using CityRide.Infrastructure;
using System;
using CityRide.Entities.Bike;

namespace CityRide.Adapters.DataAccess.Bike.Repositories
{
    public class BorrowRepository : IBorrowRepository
    {
        private readonly IMongoCollection<Entities.Bike.Borrow> _borrows;

        public BorrowRepository(DatabaseContext databaseContext)
        {
            EnsureArg.IsNotNull(databaseContext);

            _borrows = databaseContext.Borrow;
        }

        public async Task AddBorrow(Borrow borrow)
        {
            await _borrows.InsertOneAsync(borrow);
        }
    }
}
