using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
		private readonly GetMovieQueryHandler _getMovieQueryHandler;
		private readonly CreateMovieCommandHandler _createMovieCommandHandler;
		private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;
		private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;

		public MoviesController(GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieQueryHandler getMovieQueryHandler, CreateMovieCommandHandler createMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler, UpdateMovieCommandHandler updateMovieCommandHandler)
		{
			_getMovieByIdQueryHandler = getMovieByIdQueryHandler;
			_getMovieQueryHandler = getMovieQueryHandler;
			_createMovieCommandHandler = createMovieCommandHandler;
			_removeMovieCommandHandler = removeMovieCommandHandler;
			_updateMovieCommandHandler = updateMovieCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> MovieList()
		{
			var value = await _getMovieQueryHandler.Handle();
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateMovie(CreateMovieCommand command)
		{
			await _createMovieCommandHandler.Handle(command);
			return Ok("Film Ekleme İşlemi Başarıyla Gerçekleştirildi.");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteMovie(int id)
		{
			await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
			return Ok("Film Silme İşlemi Başarıyla Gerçekleştirildi.");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
		{
			await _updateMovieCommandHandler.Handle(command);
			return Ok("Film Güncelleme İşlemi Başarıyla Gerçekleştirildi.");
		}

		[HttpGet("GetMovie")]
		public async Task<IActionResult> GetMovie(int id)
		{
			var value = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
			return Ok(value);
		}
	}
}
