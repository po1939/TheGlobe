using Contracts;
using Data.DTOs;
using Data.Models;
using System;

namespace Implementations.Services
{
	public class LoginService : ILoginService
	{
		private readonly IRepository _repository;

		public LoginService(IRepository repository)
		{
			_repository = repository;
		}

		public LoginResponseDto Login(LoginRequestDto loginRequest)
		{
			var user = _repository.Get<AppUser>(x => x.Username == loginRequest.Username && x.Password == loginRequest.Password);
			if (user != null)
			{
				return new LoginResponseDto
				{
					IsSuccess = true,
					Username = user.Username,
					LoginDate = DateTime.Now
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
				_repository.Insert<AppUser>(
					new AppUser
					{
						Email = signUpRequest.Email,
						Username = signUpRequest.Username,
						Password = signUpRequest.Password
					});
				_repository.SaveChanges();
				return true;
			}
			else
			{
				return false;
			}

		}

	}
}
