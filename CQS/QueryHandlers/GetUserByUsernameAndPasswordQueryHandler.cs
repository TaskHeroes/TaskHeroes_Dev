using System.Linq;
using TaskHeroes.CQS.Queries;
using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;

namespace TaskHeroes.CQS.QueryHandlers
{
	public class GetUserByUsernameAndPasswordQueryHandler : IQueryHandler<GetUserByUsernameAndPasswordQuery, User>
	{
		private readonly TaskHeroesDbContext _dbContext;

		public GetUserByUsernameAndPasswordQueryHandler(TaskHeroesDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public User Handle(GetUserByUsernameAndPasswordQuery query)
		{
			// Get and return the user by Username and Password
			return _dbContext.Users.Where(x => x.Username == query.Username && x.Password == query.Password).FirstOrDefault();
		}
	}
}
