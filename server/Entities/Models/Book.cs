using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
	public class Book
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int BookID { get; set; }
		
		[Required]
		public string Title { get; set; }

		[Required]
		public int AuthorID { get; set; }

		[Required]
		public DateTime CreatedOn { get; set; }

		[ForeignKey("AuthorID")]
		public AppUser Author { get; set; }

		public virtual ICollection<BookTag> BookTags { get; set; }

		public virtual ICollection<Chapter> Chapters { get; set; }
	}
}
