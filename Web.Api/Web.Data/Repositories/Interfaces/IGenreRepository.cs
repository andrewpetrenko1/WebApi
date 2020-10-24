using System.Collections.Generic;
using Web.Data.Entities;

namespace Web.Data.Repositories.Interfaces
{
	public interface IGenreRepository
	{
		IEnumerable<Genre> Get();
		int Add(Genre genre);
		bool Remove(int id);
		bool Edit(Genre genre);
	}
}
