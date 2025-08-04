using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandler
{
	public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand>
	{
		private readonly MovieContext _context;

		public UpdateTagCommandHandler(MovieContext context)
		{
			_context = context;
		}

		public async Task Handle(UpdateTagCommand request, CancellationToken cancellationToken)
		{
			var value = await _context.Tags.FindAsync(request.TagID);
			value.TagTitle = request.TagTitle;
			await _context.SaveChangesAsync();
		}
	}
}
