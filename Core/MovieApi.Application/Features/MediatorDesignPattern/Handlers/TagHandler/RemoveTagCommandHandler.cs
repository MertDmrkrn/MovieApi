using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandler
{
	public class RemoveTagCommandHandler : IRequestHandler<RemoveCastCommand>
	{
		private readonly MovieContext _context;

		public RemoveTagCommandHandler(MovieContext context)
		{
			_context = context;
		}

		public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
		{
			var value = await _context.Tags.FindAsync(request.CastID);
			_context.Tags.Remove(value);
			await _context.SaveChangesAsync();
		}
	}
}
