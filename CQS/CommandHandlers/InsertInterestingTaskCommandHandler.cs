using System.Linq;
using TaskHeroes.CQS.Commands;
using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;

namespace TaskHeroes.CQS.CommandHandlers
{
	public class InsertInterestingTaskCommandHandler : ICommandHandler<InsertInterestingTaskCommand>
	{
		private readonly TaskHeroesDbContext _dbContext;

		public InsertInterestingTaskCommandHandler(TaskHeroesDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Handle(InsertInterestingTaskCommand command)
		{
			// Get interesting tasks based on UserId and TaskId
			var existingInterest = _dbContext.InterestingTasks.Where(x => x.UserId == command.UserId && x.TaskId == command.TaskId);

			// If the record already exist, return without doing anything
			if (existingInterest.Any())
				return;

			// Otherwise, create a new interesting task and map data from the command
			var newInterestingTask = new InterestingTask();
			newInterestingTask.Id = _dbContext.InterestingTasks.Any() ? _dbContext.InterestingTasks.Max(x => x.Id) + 1 : 1;
			newInterestingTask.UserId = command.UserId;
			newInterestingTask.TaskId = command.TaskId;

			// Add the new record to the table and commit changes
			_dbContext.InterestingTasks.Add(newInterestingTask);
			_dbContext.SaveChanges();
		}
	}
}
