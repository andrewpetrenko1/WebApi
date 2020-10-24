using System.Collections.Generic;

namespace Web.Data.Entities
{
	public class Genre
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Book> Books { get; set; }

		public Genre()
		{
			this.Books = new List<Book>();
		}
	}
}
