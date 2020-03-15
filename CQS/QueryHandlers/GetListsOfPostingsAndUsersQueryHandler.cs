using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskHeroes.CQS.Queries;
using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;

namespace TaskHeroes.CQS.QueryHandlers
{
	public class GetListsOfPostingsAndUsersQueryHandler : IQueryHandler<GetListsOfPostingsAndUsersQuery, Tuple<List<Data.Task>, List<User>>>
	{
		private readonly TaskHeroesDbContext _dbContext;

		public GetListsOfPostingsAndUsersQueryHandler(TaskHeroesDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Tuple<List<Data.Task>, List<User>> Handle(GetListsOfPostingsAndUsersQuery query)
		{
			var listOfPostings = _dbContext.Tasks.ToList();
			var listOfUsers = _dbContext.Users.ToList();

			return new Tuple<List<Data.Task>, List<User>>(listOfPostings, listOfUsers);
		}
	}
}
