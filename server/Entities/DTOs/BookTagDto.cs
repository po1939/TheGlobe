using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTOs
{
	public class BookTagDto
	{
		public int BookID { get; set; }

		public int TagID { get; set; }

		public virtual BookDto Book { get; set; }

		public virtual TagDto Tag { get; set; }
	}
}
