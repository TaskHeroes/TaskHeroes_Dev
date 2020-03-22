using System.Linq;
using TaskHeroes.CQS.Queries;
using TaskHeroes.CQS.TransportObjects;
using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;

namespace TaskHeroes.CQS.QueryHandlers
{
	public class GetUserDataByUserIdQueryHandler : IQueryHandler<GetUserDataByUserIdQuery, UserFullData>
	{
		private readonly TaskHeroesDbContext _dbContext;

		public GetUserDataByUserIdQueryHandler(TaskHeroesDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public UserFullData Handle(GetUserDataByUserIdQuery query)
		{
			var user = _dbContext.Users.FirstOrDefault(x => x.Id == query.UserId);
			var interestingData = _dbContext.InterestingTasks.Where(x => x.UserId == query.UserId).ToList();
			var listOfInterestingTasks = _dbContext.Tasks.AsEnumerable().Where(x => interestingData.Any(y => y.TaskId == x.Id)).ToList();
			var listOfPostingsBeingOffered = _dbContext.Tasks.Where(x => x.OffererId == query.UserId).ToList();

			return new UserFullData(user, listOfInterestingTasks, listOfPostingsBeingOffered);
		}
	}
}
