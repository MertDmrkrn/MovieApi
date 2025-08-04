using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueris
{
	public class GetTagByIdQuery:IRequest<GetTagByIdQueryResult>
	{
		public GetTagByIdQuery(int tagID)
		{
			TagID = tagID;
		}

		public int TagID { get; set; }
	}
}
