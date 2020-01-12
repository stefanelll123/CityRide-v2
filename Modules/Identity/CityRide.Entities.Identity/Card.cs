namespace CityRide.Entities.Identity
{
    public sealed class Card
    {
        private Card(string cardNumber, string cardHolderName, string expirationDate)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            ExpirationDate = expirationDate;
        }

        public string CardNumber { get; private set; }

        public string CardHolderName { get; private set; }

        public string ExpirationDate { get; private set; }

        public static Card Create(string cardNumber, string cardHolderName, string expirationDate)
        {
            return new Card(cardNumber, cardHolderName, expirationDate);
        }
    }
}
