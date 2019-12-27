using System;

namespace CityRide.Ports.Web.Bike.Models
{
    public class BorrowResponseModel
    {
        public BorrowResponseModel()
        {
            Found = false;
            Borrowable = false;
        }

        public bool Found { get; private set; }

        public bool Borrowable { get; private set; }

        public void MarkAsFound() => Found = true;

        public void MarkAsBorrowable() => Borrowable = true;
    }
}
