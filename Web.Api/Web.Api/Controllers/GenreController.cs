using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Business.Domains.Interfaces;
using Web.Business.ViewModels;

namespace Web.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenreController : ControllerBase
	{
		private IGenreDomain _genreDomain;

		public GenreController(IGenreDomain genreDomain)
		{
			_genreDomain = genreDomain;
		}

		[HttpGet]
		public IActionResult Get() => Ok(_genreDomain.Get());

		[HttpPost]
		public IActionResult Post(GenreViewModel genreView)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			int id = _genreDomain.Add(genreView);
			if(id > 0)
			{
				genreView.Id = id;
				return Ok(genreView);
			}
			return BadRequest();
		}

		[HttpPut]
		public IActionResult Put(GenreViewModel genreView)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (_genreDomain.Edit(genreView))
				return Ok();

			return BadRequest();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			if (_genreDomain.Remove(id))
				return Ok();

			return BadRequest();
		}
	}
}
