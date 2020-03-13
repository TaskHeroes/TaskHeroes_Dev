using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskHeroes.CQS.Commands;
using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;

namespace TaskHeroes.CQS.CommandHandlers
{
	public class EditUserProfileCommandHandler : ICommandHandler<EditUserProfileCommand>
	{
		private readonly TaskHeroesDbContext _dbContext;

		public EditUserProfileCommandHandler(TaskHeroesDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Handle(EditUserProfileCommand command)
		{
			var user = _dbContext.Users.SingleOrDefault(x => x.Id == command.UserId);

			if (user != null)
			{
				user.Username = command.Username;
				user.Password = command.Password;
				user.Email = command.Email;
				user.FirstName = command.FirstName;
				user.LastName = command.LastName;
				user.Description = command.Description;
				user.City = command.City;
				user.Province = command.Province;
				_dbContext.SaveChanges();
			}
		}
	}
}
