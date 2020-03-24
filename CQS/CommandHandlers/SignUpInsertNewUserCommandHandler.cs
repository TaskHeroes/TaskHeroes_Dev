using System;
using System.Linq;
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
			// Set the new user's Id to either 1 or the max Id + 1 depending on whethere it's the first user in the table
			command.NewUser.Id = _dbContext.Users.Any() ? _dbContext.Users.Max(x => x.Id) + 1 : 1;

			// Set timestamp to current time
			command.NewUser.DateCreated = DateTime.Now;

			// Set image path
			command.NewUser.Image = "~/Resources/Images/UserProfile/profile_picture_" + command.NewUser.Id + ".jpg";

			// Add the record to the Users table and commit changes
			_dbContext.Users.Add(command.NewUser);
			_dbContext.SaveChanges();
		}
	}
}
