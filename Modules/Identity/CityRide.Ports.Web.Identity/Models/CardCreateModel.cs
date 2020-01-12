namespace CityRide.Ports.Web.Identity.Models
{
    public sealed class CardCreateModel
    {
        public string CardNumber { get; set; }

        public string CardHolderName { get; set; }

        public string ExpirationDate { get; set; }
    }
}
