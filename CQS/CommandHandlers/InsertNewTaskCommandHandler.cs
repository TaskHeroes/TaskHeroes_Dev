using System.Linq;
using TaskHeroes.CQS.Commands;
using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;
using Task = TaskHeroes.Data.Task;

namespace TaskHeroes.CQS.CommandHandlers
{
	public class InsertNewTaskCommandHandler : ICommandHandler<InsertNewTaskCommand>
	{
		private readonly TaskHeroesDbContext _dbContext;

		public InsertNewTaskCommandHandler(TaskHeroesDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Handle(InsertNewTaskCommand command)
		{
			// Create new task and map data from the command
			var newTask = new Task();
			newTask.Title = command.Title;
			newTask.Description = command.Description;
			newTask.JobType = command.JobType;
			newTask.MoneyOffer = command.MoneyOffer;
			newTask.WorkPeriod = command.WorkPeriod;
			newTask.OffererId = command.OffererId;
			// Set the new task's Id to either 1 or the max Id + 1 depending on whethere it's the first task in the table
			newTask.Id = _dbContext.Tasks.Any() ? _dbContext.Tasks.Max(x => x.Id) + 1 : 1;

			// Add the new task record to the Tasks table and commit changes
			_dbContext.Tasks.Add(newTask);
			_dbContext.SaveChanges();
		}
	}
}
