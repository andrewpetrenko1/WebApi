using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Web.Business.Domains.Interfaces;
using Web.Business.ViewModels;
using Web.Data.Entities;
using Web.Data.Repositories.Interfaces;

namespace Web.Business.Domains
{
	public class GenreDomain : IGenreDomain
	{
		private IMapper _mapper;
		private readonly IGenreRepository _genreRepository;

		public GenreDomain(IGenreRepository genreRepository, IMapper mapper)
		{
			this._genreRepository = genreRepository;
			this._mapper = mapper;
		}

		public IEnumerable<GenreViewModel> Get() => 
			_mapper.Map<IEnumerable<Genre>, IEnumerable<GenreViewModel>>(_genreRepository.Get());

		public int Add(GenreViewModel genreView) =>
			_genreRepository.Add(_mapper.Map<GenreViewModel, Genre>(genreView));

		public bool Remove(int id) => _genreRepository.Remove(id);

		public bool Edit(GenreViewModel genreView) =>
			_genreRepository.Edit(_mapper.Map<GenreViewModel, Genre>(genreView));
	}
}
