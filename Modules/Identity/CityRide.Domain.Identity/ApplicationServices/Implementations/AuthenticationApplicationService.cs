using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using CityRide.Domain.Identity.ApplicationServices.Interfaces;
using CityRide.Domain.Identity.DomainServices.Interfaces;
using CityRide.Entities.Identity;
using CityRide.Entities.Identity.Dtos;
using CityRide.Infrastructure;
using CityRide.Interop.DataAccess.Identity.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CityRide.Domain.Identity.ApplicationServices.Implementations
{
    internal sealed class AuthenticationApplicationService : IAuthenticationApplicationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IConfiguration _config;

        public AuthenticationApplicationService(IUserRepository userRepository, IPasswordHasher passwordHasher, IConfiguration config)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _config = config;
        }

        async Task<Result> IAuthenticationApplicationService.Login(UserAuthenticationDto userAuthenticationDto)
        {
            var user = await _userRepository.GetUserBy(userAuthenticationDto.Email);
            if (user == null)
            {
                return Result.Error(HttpStatusCode.Unauthorized, Resource.Unauthorized);
            }

            return _passwordHasher.Check(user.Password, userAuthenticationDto.Password) ?
                Result.Ok(GenerateToken(user)) :
                Result.Error(HttpStatusCode.Unauthorized, Resource.Unauthorized);
        }

        private AuthenticationDto GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtOptions:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var hours = int.Parse(_config["JwtOptions:TokenExpirationInHours"]);

            var token = new JwtSecurityToken(_config["JwtOptions:Issuer"],
                _config["JwtOptions:Issuer"],
                null,
                expires: DateTime.Now.AddHours(hours),
                signingCredentials: credentials);

            return AuthenticationDto.Create(user.FullName, new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
