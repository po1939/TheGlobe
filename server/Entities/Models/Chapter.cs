using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
	public class Chapter
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ChapterID { get; set; }

		public string ChapterName { get; set; }

		[Required]
		public int BookID { get; set; }

		[Required]
		public DateTime WriteDate { get; set; }

		[Required]
		public string Content { get; set; }

		[ForeignKey("BookID")]
		public virtual Book Book { get; set; }

	}
}
