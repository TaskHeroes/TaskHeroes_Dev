using System.Linq;
using TaskHeroes.CQS.Queries;
using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;

namespace TaskHeroes.CQS.QueryHandlers
{
	public class GetUserByUserIdQueryHandler : IQueryHandler<GetUserByUserIdQuery, User>
	{
		private readonly TaskHeroesDbContext _dbContext;

		public GetUserByUserIdQueryHandler(TaskHeroesDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public User Handle(GetUserByUserIdQuery query)
		{
			return _dbContext.Users.FirstOrDefault(x => x.Id == query.UserId);
		}
	}
}
