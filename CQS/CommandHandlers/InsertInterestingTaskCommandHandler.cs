using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
			var existingInterest = _dbContext.InterestingTasks.Where(x => x.UserId == command.UserId && x.TaskId == command.TaskId);

			if (existingInterest.Any())
				return;

			var newInterestingTask = new InterestingTask();
			newInterestingTask.Id = _dbContext.InterestingTasks.Any() ? _dbContext.InterestingTasks.Max(x => x.Id) + 1 : 1;
			newInterestingTask.UserId = command.UserId;
			newInterestingTask.TaskId = command.TaskId;
			_dbContext.InterestingTasks.Add(newInterestingTask);
			_dbContext.SaveChanges();
		}
	}
}
