namespace CityRide.Entities.Bike.Dtos
{
    public sealed class ReturnEmailDto
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Total { get; set; }

        public static ReturnEmailDto Create(string fullName, string email, string total)
        {
            return new ReturnEmailDto
            {
                FullName = fullName,
                Email = email,
                Total = total
            };
        }
    }
}
