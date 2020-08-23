using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Common.Helpers
{
    public static class PasswordHasher
    {
		public static string CreateHashedPassword(string password, string salt)
		{
			var valueBytes = KeyDerivation.Pbkdf2(
								password: password,
								salt: Encoding.UTF8.GetBytes(salt),
								prf: KeyDerivationPrf.HMACSHA512,
								iterationCount: 10000,
								numBytesRequested: 256 / 8);

			return Convert.ToBase64String(valueBytes);
		}

		public static bool Validate(string password, string salt, string hash)
		{
			string hashed = CreateHashedPassword(password, salt);
			return hashed == hash;
		}

		public static string CreateSalt()
		{
			byte[] randomBytes = new byte[128 / 8];
			using (var generator = RandomNumberGenerator.Create())
			{
				generator.GetBytes(randomBytes);
				return Convert.ToBase64String(randomBytes);
			}
		}

	}
}
