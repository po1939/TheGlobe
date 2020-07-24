using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options)
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<BookTag>()
				.HasKey(c => new { c.BookID, c.TagID });
		}

		public DbSet<AppUser> AppUsers { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<BookTag> BookTags { get; set; }
		public DbSet<Chapter> Chapters { get; set; }

	}
}
