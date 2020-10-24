using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Web.Data.Entities;
using Web.Data.Repositories.Interfaces;

namespace Web.Data.Repositories
{
	public class GenreRepository : IGenreRepository
	{
		private readonly IWebApiDbContext _context;

		public GenreRepository(IWebApiDbContext context)
		{
			this._context = context;
		}

		public IEnumerable<Genre> Get() =>
			_context.Genres.Include(g => g.Books).ToList();

		public int Add(Genre genre)
		{
			_context.Genres.Add(genre);
			_context.SaveChanges();
			return genre.Id;
		}

		public bool Remove(int id)
		{
			_context.Genres.Remove(_context.Genres.Find(id));
			if (_context.SaveChanges() > 0)
				return true;

			return false;
		}

		public bool Edit(Genre genre)
		{
			var oldGenre = _context.Genres.Find(genre.Id);
			oldGenre.Name = genre.Name;
			if (_context.SaveChanges() > 0)
				return true;

			return false;
		}
	}
}
