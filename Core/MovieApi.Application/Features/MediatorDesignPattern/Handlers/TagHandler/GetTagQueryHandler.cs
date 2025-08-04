using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueris;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandler
{
	public class GetTagQueryHandler : IRequestHandler<GetTagQuery, List<GetTagQueryResult>>
	{
		private readonly MovieContext _context;

		public GetTagQueryHandler(MovieContext context)
		{
			_context = context;
		}

		public async Task<List<GetTagQueryResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
		{
			var value = await _context.Tags.ToListAsync();
			return value.Select(x => new GetTagQueryResult
			{
				TagID = x.TagID,
				TagTitle = x.TagTitle
			}).ToList();
		}
	}
}
