using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandler
{
	public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>//İstek nerden gerçekleştirileceğini soruyor ve bu istek commandsta yazdığımız CreateCastCommanddan gelecek
	{
		private readonly MovieContext _context;

		public CreateCastCommandHandler(MovieContext context)
		{
			_context = context;
		}

		public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)//Burada bulunan CancellationToken, uzun süren ya da potansiyel olarak uzun sürebilecek işlemlerin iptal edilebilirliğini sağlar. Kısaca işlemin dışarıdan iptal edilebilir olmasını sağlar. Bu, uygulamanın daha verimli çalışmasını ve kullanıcı deneyiminin iyileşmesini sağlar.
		{
			await _context.Casts.AddAsync(new Cast
			{
				Biography = request.Biography,
				ImgUrl = request.ImgUrl,
				CastTitle = request.CastTitle,
				Name = request.Name,
				Overview = request.Overview,
				Surname = request.Surname
			});
			await _context.SaveChangesAsync();
		}
	}
}
