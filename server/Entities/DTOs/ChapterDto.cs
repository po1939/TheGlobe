using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTOs
{
	public class ChapterDto
	{
		public int ChapterID { get; set; }

		public string ChapterName { get; set; }

		public int BookID { get; set; }

		public DateTime WriteDate { get; set; }

		public string Content { get; set; }

		public virtual BookDto Book { get; set; }
	}
}
