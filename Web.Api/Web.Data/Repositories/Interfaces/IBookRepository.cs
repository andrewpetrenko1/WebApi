using System.Collections.Generic;
using Web.Data.Entities;

namespace Web.Data.Repositories.Interfaces
{
	public interface IBookRepository
	{
		IEnumerable<Book> Get();
		int Add(Book book);
		bool Remove(int id);
		bool Edit(Book book);
	}
}
