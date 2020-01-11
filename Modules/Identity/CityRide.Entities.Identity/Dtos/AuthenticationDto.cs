namespace CityRide.Entities.Identity.Dtos
{
    public sealed class AuthenticationDto
    {
        private AuthenticationDto(string fullName, string token, string email)
        {
            FullName = fullName;
            Token = token;
            Email = email;
        }

        public string FullName { get; private set; }

        public string Email { get; private set; }

        public string Token { get; private set; }

        public static AuthenticationDto Create(string fullName, string token, string email)
        {
            return new AuthenticationDto(fullName, token, email);
        }
    }
}
