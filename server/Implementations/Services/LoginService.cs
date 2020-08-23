using Common.Helpers;
using Contracts;
using Data.DTOs;
using Data.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Implementations.Services
{
	public class LoginService : ILoginService
	{
		private readonly IRepository _repository;
		private readonly AppSettings _appSettings;


		public LoginService(IRepository repository, IOptions<AppSettings> appSettings)
		{
			_repository = repository;
			_appSettings = appSettings.Value;

		}


		public LoginResponseDto Login(LoginRequestDto loginRequest)
		{
			var user = _repository.Get<AppUser>(x => x.Username == loginRequest.Username);

			// record exists and hash validate passes
			if (user != null && PasswordHasher.Validate(loginRequest.Password, user.Salt, user.Password))
			{
				var token = generateJwtToken(user);
				return new LoginResponseDto
				{
					IsSuccess = true,
					Username = user.Username,
					LoginDate = DateTime.Now,
					Token = token
				};
			}
			else
			{
				return new LoginResponseDto
				{
					IsSuccess = false
				};
			}
		}

		public bool SignUp(SignUpRequestDto signUpRequest)
		{
			var user = _repository.Get<AppUser>(x => x.Username == signUpRequest.Username || x.Email == signUpRequest.Email);
			if (user == null)
			{
				string salt = PasswordHasher.CreateSalt();
				string hash = PasswordHasher.CreateHashedPassword(signUpRequest.Password, salt);

				_repository.Insert<AppUser>(
					new AppUser
					{
						Email = signUpRequest.Email,
						Username = signUpRequest.Username,
						Salt = salt,
						Password = hash
					});
				_repository.SaveChanges();
				return true;
			}
			else
			{
				return false;
			}

		}
		private string generateJwtToken(AppUser user)
		{
			// generate token that is valid for 7 days
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.AppUserID.ToString())
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

	}
}
