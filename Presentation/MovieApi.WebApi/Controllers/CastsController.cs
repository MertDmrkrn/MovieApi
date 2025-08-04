using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;

namespace MovieApi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CastsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CastsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult> CastList()
		{
			var values = await _mediator.Send(new GetCastQuery());//Buradaki Send() methodu gidilecek handle'ı ya da handler'ı belirliyor.
			return Ok(values);
		}

		[HttpPost]
		public async Task<ActionResult> CreateCast(CreateCastCommand command)
		{
			await _mediator.Send(command);
			return Ok("Ekleme İşlemi Başarıyla Gerçekleştirildi.");
		}

		[HttpDelete]
		public async Task<ActionResult> RemoveCast(int id)
		{
			await _mediator.Send(new RemoveCastCommand(id));
			return Ok("Silme İşlemi Başarıyla Gerçekleştirildi.");
		}

		[HttpGet("GetCastById")]
		public async Task<ActionResult> GetCastById(int id)
		{
			var value =await _mediator.Send(new GetCastByIdQuery(id));
			return Ok(value);
		}


		[HttpPut]
		public async Task<ActionResult> UpdateCast(UpdateCastCommand command)
		{
			await _mediator.Send(command);
			return Ok("Güncelleme İşlemi Başarıyla Gerçekleştirildi.");
		}
	}
}
