using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTOs
{
	public class BookDto
	{
		public int BookID { get; set; }

		public string Title { get; set; }

		public int AuthorID { get; set; }

		public DateTime CreatedOn { get; set; }

		public AppUserDto Author { get; set; }

		public virtual List<BookTagDto> BookTags { get; set; }

		public virtual List<ChapterDto> Chapters { get; set; }
	}
}
