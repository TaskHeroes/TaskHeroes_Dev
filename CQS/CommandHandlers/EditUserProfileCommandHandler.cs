using System.Linq;
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
			// Get the user by UserId
			var user = _dbContext.Users.SingleOrDefault(x => x.Id == command.UserId);

			// If the user exists, update it with the new data
			if (user != null)
			{
				// Update the existing user record with new data
				user.Email = command.Email;
				user.FirstName = command.FirstName;
				user.LastName = command.LastName;
				user.Description = command.Description;
				user.City = command.City;
				user.Province = command.Province;

				// Commit changes to the database
				_dbContext.SaveChanges();
			}
		}
	}
}
