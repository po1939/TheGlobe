using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTOs
{
	public class AppUserDto
	{
		public int AppUserID { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public bool IsAdmin { get; set; }
		public int Rank { get; set; }
	}
}
