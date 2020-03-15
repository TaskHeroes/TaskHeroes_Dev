using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
			var newTask = new Task();
			newTask.Title = command.Title;
			newTask.Description = command.Description;
			newTask.JobType = command.JobType;
			newTask.MoneyOffer = command.MoneyOffer;
			newTask.WorkPeriod = command.WorkPeriod;
			newTask.OffererId = command.OffererId;
			newTask.Id = _dbContext.Tasks.Any() ? _dbContext.Tasks.Max(x => x.Id) + 1 : 1;

			_dbContext.Tasks.Add(newTask);
			_dbContext.SaveChanges();
		}
	}
}
