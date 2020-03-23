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
			// Get user by UserId
			var user = _dbContext.Users.FirstOrDefault(x => x.Id == query.UserId);

			// Get list of tasks that the user is interested in
			var interestingData = _dbContext.InterestingTasks.Where(x => x.UserId == query.UserId).ToList();
			var listOfInterestingTasks = _dbContext.Tasks.AsEnumerable().Where(x => interestingData.Any(y => y.TaskId == x.Id)).ToList();

			// Get list of tasks that the user created/offers
			var listOfPostingsBeingOffered = _dbContext.Tasks.Where(x => x.OffererId == query.UserId).ToList();

			// Combine the data into a UserFullData transport object and return
			return new UserFullData(user, listOfInterestingTasks, listOfPostingsBeingOffered);
		}
	}
}
