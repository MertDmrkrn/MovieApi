using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
	public class GetMovieByIdQueryHandler
	{
		private readonly MovieContext _context;

		public GetMovieByIdQueryHandler(MovieContext context)
		{
			_context = context;
		}

		public async Task<GetMovieByIdResult> Handle(GetMovieByIdQuery query)
		{
			var value = await _context.Movies.FindAsync(query.MovieID);
			return new GetMovieByIdResult
			{
				MovieID = value.MovieID,
				CoverImgUrl = value.CoverImgUrl,
				CreatedYear = value.CreatedYear,
				Description = value.Description,
				Duration = value.Duration,
				MovieTitle = value.MovieTitle,
				Rating = value.Rating,
				ReleaseDate = value.ReleaseDate,
				Status = value.Status
			};
		}
	}
}
