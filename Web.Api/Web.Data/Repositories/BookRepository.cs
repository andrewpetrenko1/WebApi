using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Web.Data.Entities;
using Web.Data.Repositories.Interfaces;

namespace Web.Data.Repositories
{
	public class BookRepository : IBookRepository
	{
		private readonly IWebApiDbContext _context;

		public BookRepository(IWebApiDbContext context)
		{
			this._context = context;
		}

		public IEnumerable<Book> Get() =>
			_context.Books.Include(b => b.Genre).ToList();

		public int Add(Book book)
		{
			_context.Books.Add(book);
			_context.SaveChanges();
			return book.Id;
		}

		public bool Edit(Book book)
		{
			var oldBook = _context.Books.Find(book.Id);
			EditBookValues(oldBook, book);

			if (_context.SaveChanges() > 0)
				return true;

			return false;
		}

		private void EditBookValues(Book oldBook, Book editedBook)
		{
			foreach (var bookP in oldBook.GetType().GetProperties())
			{
				var editedBookValue = bookP.GetValue(editedBook);
				if (editedBookValue != null && (editedBookValue.ToString() != bookP.GetValue(oldBook).ToString()))
				{
					bookP.SetValue(oldBook, editedBookValue);
				}
			}
		}

		public bool Remove(int id)
		{
			_context.Books.Remove(_context.Books.Find(id));
			if (_context.SaveChanges() > 0)
				return true;

			return false;
		}
	}
}
