using Microsoft.EntityFrameworkCore;
using Web.Data.Entities;

namespace Web.Data
{
	public class WebApiDbContext : DbContext, IWebApiDbContext
	{
		public WebApiDbContext(DbContextOptions options) : base(options)
		{  }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Book>()
				.Property(b => b.Title)
				.IsRequired()
				.HasMaxLength(100);

			builder.Entity<Book>()
				.Property(b => b.Publisher)
				.HasMaxLength(100);

			builder.Entity<Book>()
				.HasOne(b => b.Genre)
				.WithMany(g => g.Books)
				.HasForeignKey(b => b.GenreId);

			builder.Entity<Genre>()
				.Property(g => g.Name)
				.IsRequired()
				.HasMaxLength(50);
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Genre> Genres { get; set; }
	}
}
