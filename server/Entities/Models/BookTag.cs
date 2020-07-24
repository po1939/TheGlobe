using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
	public class BookTag
	{
		[Key]
		[Column(Order = 0)]
		public int BookID { get; set; }

		[Key]
		[Column(Order = 0)]
		public int TagID { get; set; }

		[ForeignKey("BookID")]
		public virtual Book Book { get; set; }

		[ForeignKey("TagID")]
		public virtual Tag Tag { get; set; }
	}
}
