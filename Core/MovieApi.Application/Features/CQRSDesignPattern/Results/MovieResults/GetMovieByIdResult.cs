using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults
{
	public class GetMovieByIdResult
	{
		public int MovieID { get; set; }

		public string MovieTitle { get; set; }

		public string CoverImgUrl { get; set; }

		public decimal Rating { get; set; }

		public string Description { get; set; }

		public int Duration { get; set; }

		public DateTime ReleaseDate { get; set; }

		public string CreatedYear { get; set; }

		public bool Status { get; set; }
	}
}
