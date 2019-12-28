namespace CityRide.Entities.Identity.Dtos
{
    public sealed class AuthenticationDto
    {
        private AuthenticationDto(string fullName, string token)
        {
            FullName = fullName;
            Token = token;
        }

        public string FullName { get; private set; }

        public string Token { get; private set; }

        public static AuthenticationDto Create(string fullName, string token)
        {
            return new AuthenticationDto(fullName, token);
        }
    }
}
