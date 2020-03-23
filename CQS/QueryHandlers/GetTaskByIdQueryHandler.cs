using System.Linq;
using TaskHeroes.CQS.Queries;
using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;

namespace TaskHeroes.CQS.QueryHandlers
{
	public class GetTaskByIdQueryHandler : IQueryHandler<GetTaskByIdQuery, Task>
	{
		private readonly TaskHeroesDbContext _dbContext;

		public GetTaskByIdQueryHandler(TaskHeroesDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Task Handle(GetTaskByIdQuery query)
		{
			// Get and return task by TaskId
			return _dbContext.Tasks.FirstOrDefault(x => x.Id == query.TaskId);
		}
	}
}
