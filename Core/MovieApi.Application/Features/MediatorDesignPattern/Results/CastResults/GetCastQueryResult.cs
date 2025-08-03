using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults
{
	public class GetCastQueryResult
	{
		public int CastID { get; set; }

		public string CastTitle { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public string ImgUrl { get; set; }

		public string? Overview { get; set; }

		public string? Biography { get; set; }
	}
}
