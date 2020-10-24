using System.Collections.Generic;
using Web.Business.ViewModels;

namespace Web.Business.Domains
{
	public interface IBookDomain
	{
		IEnumerable<BookViewModel> Get();
		int Add(BookViewModel bookView);
		bool Remove(int id);
		bool Edit(BookViewModel bookView);
	}
}
