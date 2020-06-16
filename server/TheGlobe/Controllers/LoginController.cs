using Contracts;
using Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Common.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace TheGlobeServer.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	public class LoginController : ControllerBase
	{
		private readonly ILoginService _loginService;
		public LoginController(ILoginService loginService)
		{
			this._loginService = loginService;
		}


		[AllowAnonymous]
		[HttpPost]
		public async Task<ActionResult<LoginResponseDto>> Login([FromBody]LoginRequestDto loginRequest)
		{
			if (ModelState.IsValid)
			{
				var result = _loginService.Login(loginRequest);
				return result;
			}
			else
			{
				return new LoginResponseDto { IsSuccess = false };
			}
		}




		[HttpPost("signup")]
		public async Task<ActionResult> SignUp([FromBody] SignUpRequestDto signUpRequest)
		{
			if (ModelState.IsValid)
			{
				var created = _loginService.SignUp(signUpRequest);
				if (created)
				{
					return Ok();
				}
			}
			return BadRequest();
		}
	}
}
