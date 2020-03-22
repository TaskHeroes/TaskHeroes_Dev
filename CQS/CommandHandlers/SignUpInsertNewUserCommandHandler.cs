using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskHeroes.CQS.Commands;
using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;

namespace TaskHeroes.CQS.CommandHandlers
{
	public class SignUpInsertNewUserCommandHandler : ICommandHandler<SignUpInsertNewUserCommand>
	{
		private readonly TaskHeroesDbContext _dbContext;

		public SignUpInsertNewUserCommandHandler(TaskHeroesDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Handle(SignUpInsertNewUserCommand command)
		{
			command.NewUser.Id = _dbContext.Users.Any() ? _dbContext.Users.Max(x => x.Id) + 1 : 1;
			command.NewUser.DateCreated = DateTime.Now;
			_dbContext.Users.Add(command.NewUser);

			_dbContext.SaveChanges();
		}
	}
}
