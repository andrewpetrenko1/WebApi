using Microsoft.AspNetCore.Mvc;
using Web.Business.Domains;
using Web.Business.ViewModels;

namespace Web.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private IBookDomain _bookDomain;

		public BookController(IBookDomain bookDomain)
		{
			_bookDomain = bookDomain;
		}

		[HttpGet]
		public IActionResult Get() => Ok(_bookDomain.Get());

		[HttpPost]
		public IActionResult Post(BookViewModel bookView)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			int id = _bookDomain.Add(bookView);
			if (id > 0)
			{
				bookView.Id = id;
				return Ok(bookView);
			}
			return BadRequest();
		}

		[HttpPut]
		public IActionResult Put(BookViewModel bookView)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (_bookDomain.Edit(bookView))
				return Ok(bookView);

			return BadRequest();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			if (_bookDomain.Remove(id))
				return Ok();

			return BadRequest();
		}
	}
}
