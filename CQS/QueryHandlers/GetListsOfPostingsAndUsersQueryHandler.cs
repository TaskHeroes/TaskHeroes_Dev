using System;
using System.Collections.Generic;
using System.Linq;
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
			// Retrieve the list of all tasks in the database
			var listOfPostings = _dbContext.Tasks.ToList();

			// Retrieve the list of all users in the dtabase
			var listOfUsers = _dbContext.Users.ToList();

			// Combine the two lists into a Tuple object and return
			return new Tuple<List<Data.Task>, List<User>>(listOfPostings, listOfUsers);
		}
	}
}
