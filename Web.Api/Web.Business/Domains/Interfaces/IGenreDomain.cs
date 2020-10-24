using System.Collections.Generic;
using Web.Business.ViewModels;

namespace Web.Business.Domains.Interfaces
{
	public interface IGenreDomain
	{
		IEnumerable<GenreViewModel> Get();
		int Add(GenreViewModel genreView);
		bool Remove(int id);
		bool Edit(GenreViewModel genreView);
	}
}
