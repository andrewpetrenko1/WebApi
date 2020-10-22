using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Web.Data.Entities;

namespace Web.Data
{
	class WebApiDbContext : DbContext
	{
		private readonly IConfiguration _configuration;
		public WebApiDbContext(IConfiguration configuration) : base()
		{
			this._configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			builder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			
		}

		public DbSet<Book> Books { get; set; }
	}
}
