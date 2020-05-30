using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.DTOs
{
	public class LoginRequestDto
	{
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
	}

	public class LoginResponseDto
	{
		public bool IsSuccess { get; set; }
		public string Username { get; set; }
		public DateTime LoginDate { get; set; }
		public string AuthToken { get; set; }
	}
}
