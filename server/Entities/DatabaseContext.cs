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

		public DbSet<AppUser> AppUsers { get; set; }
	}
}
