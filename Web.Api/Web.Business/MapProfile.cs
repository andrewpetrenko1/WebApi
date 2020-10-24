using AutoMapper;
using Web.Business.ViewModels;
using Web.Data.Entities;

namespace Web.Business
{
  public class MapProfile : Profile
  {
    public MapProfile()
    {
      //CreateMap<Book, BookViewModel>()
      //	 .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.Genre.Name));

      CreateMap<Book, BookViewModel>().ReverseMap();
      CreateMap<Genre, GenreViewModel>().ReverseMap();
    }
  }
}
