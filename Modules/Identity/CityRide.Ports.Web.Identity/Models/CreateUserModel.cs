namespace CityRide.Ports.Web.Identity.Models
{
    public class CreateUserModel
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
