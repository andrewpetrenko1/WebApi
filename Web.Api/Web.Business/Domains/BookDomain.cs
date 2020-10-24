using AutoMapper;
using System.Collections.Generic;
using Web.Business.ViewModels;
using Web.Data.Entities;
using Web.Data.Repositories.Interfaces;

namespace Web.Business.Domains
{
	public class BookDomain : IBookDomain
	{
		private readonly IMapper _mapper;
		private readonly IBookRepository _bookRepository;

		public BookDomain(IBookRepository bookRepository, IMapper mapper)
		{
			this._bookRepository = bookRepository;
			this._mapper = mapper;
		}

		public IEnumerable<BookViewModel> Get() => 
			_mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(_bookRepository.Get());

		public int Add(BookViewModel bookView) =>
			_bookRepository.Add(_mapper.Map<BookViewModel, Book>(bookView));

		public bool Remove(int id) => _bookRepository.Remove(id);

		public bool Edit(BookViewModel bookView) =>
			_bookRepository.Edit(_mapper.Map<BookViewModel, Book>(bookView));
	}
}
