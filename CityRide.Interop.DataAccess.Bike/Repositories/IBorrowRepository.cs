using System.Threading.Tasks;

namespace CityRide.Interop.DataAccess.Bike.Repositories
{
    public interface IBorrowRepository
    {
        Task AddBorrow(Entities.Bike.Borrow borrow);
    }
}
