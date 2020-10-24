using Microsoft.EntityFrameworkCore;
using Web.Data.Entities;

namespace Web.Data
{
	public interface IWebApiDbContext
	{
		public DbSet<Book> Books { get; set; }
		public DbSet<Genre> Genres { get; set; }

		int SaveChanges();
	}
}
