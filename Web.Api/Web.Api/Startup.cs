using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Business.Domains;
using Web.Business.Domains.Interfaces;
using Web.Data.Repositories;
using Web.Data.Repositories.Interfaces;

namespace Web.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddDbContext<Data.IWebApiDbContext, Data.WebApiDbContext>(builder =>
				builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			// Repositories
			services.AddTransient<IBookRepository, BookRepository>();
			services.AddTransient<IGenreRepository, GenreRepository>();

			// Domains
			services.AddTransient<IBookDomain, BookDomain>();
			services.AddTransient<IGenreDomain, GenreDomain>();

			// AutoMapper
			var mapConfig = new MapperConfiguration(mc => mc.AddProfile(new Business.MapProfile()));
			services.AddSingleton(mapConfig.CreateMapper());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
