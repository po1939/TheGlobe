using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
	public class AppUser
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AppUserID { get; set; }

		[Required(ErrorMessage = "Username is required.")]
		[StringLength(30,ErrorMessage = "Username cannot be longer than 30 characters.")]
		public string Username { get; set; }

		public string Salt { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public bool IsAdmin { get; set; }
		public int Rank { get; set; }
	}
}
