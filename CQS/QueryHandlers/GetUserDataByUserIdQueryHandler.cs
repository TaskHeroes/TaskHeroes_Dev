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
			var ratingData = _dbContext.Ratings.FirstOrDefault(x => x.Id == query.UserId);
			var rating = ratingData == null || ratingData.NumberOfRatings == 0 ? 0 : ratingData.RatingTotal / ratingData.NumberOfRatings;
			var taskHistory = _dbContext.Tasks.Where(x => x.OffererId == query.UserId).ToList(); // TODO: Use SeekerID when getting task history
			var listOfPostingsBeingOffered = _dbContext.Tasks.Where(x => x.OffererId == query.UserId).ToList();

			return new UserFullData(user, rating, taskHistory, listOfPostingsBeingOffered);
		}
	}
}
