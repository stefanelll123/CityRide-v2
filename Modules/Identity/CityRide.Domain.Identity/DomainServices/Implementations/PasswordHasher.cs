﻿using System;
using System.Linq;
using System.Security.Cryptography;

using CityRide.Domain.Identity.DomainServices.Interfaces;

namespace CityRide.Domain.Identity.DomainServices.Implementations
{
    internal sealed class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 1000;

        string IPasswordHasher.Hash(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                SaltSize,
                Iterations,
                HashAlgorithmName.SHA256))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return $"{salt}.{key}";
            }
        }

        bool IPasswordHasher.Check(string hash, string password)
        {
            var parts = hash.Split('.', 3);
            if (parts.Length != 2)
            {
                throw new FormatException("Unexpected hash format. " +
                                          "Should be formatted as `{iterations}.{salt}.{hash}`");
            }

            var salt = Convert.FromBase64String(parts[0]);
            var key = Convert.FromBase64String(parts[1]);

            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256))
            {
                var keyToCheck = algorithm.GetBytes(KeySize);
                var verified = keyToCheck.SequenceEqual(key);

                return verified;
            }
        }
    }
}
