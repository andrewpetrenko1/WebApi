using System.ComponentModel.DataAnnotations;

namespace Web.Business.ViewModels
{
	public class BookViewModel
	{
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		public string Author { get; set; }
		[Required]
		public int GenreId { get; set; }
		public int Year { get; set; }
		public string Publisher { get; set; }
	}
}
