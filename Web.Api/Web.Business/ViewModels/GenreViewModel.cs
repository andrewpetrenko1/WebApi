using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Business.ViewModels
{
	public class GenreViewModel
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public List<BookViewModel> Books { get; set; }

		public GenreViewModel()
		{
			this.Books = new List<BookViewModel>();
		}
	}
}
