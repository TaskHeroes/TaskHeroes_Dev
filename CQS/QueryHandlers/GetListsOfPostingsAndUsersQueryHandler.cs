using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskHeroes.CQS.Queries;
using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;

namespace TaskHeroes.CQS.QueryHandlers
{
	public class GetListsOfPostingsAndUsersQueryHandler : IQueryHandler<GetListsOfPostingsAndUsersQuery, Tuple<List<Posting>, List<User>>>
	{
		private readonly TaskHeroesDbContext _dbContext;

		public GetListsOfPostingsAndUsersQueryHandler(TaskHeroesDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Tuple<List<Posting>, List<User>> Handle(GetListsOfPostingsAndUsersQuery query)
		{
			var listOfPostings = _dbContext.Postings.ToList();
			var listOfUsers = _dbContext.Users.ToList();

			return new Tuple<List<Posting>, List<User>>(listOfPostings, listOfUsers);
		}
	}
}
