using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;

namespace TaskHeroes.CQS.Commands
{
	public class SignUpInsertNewUserCommand : ICommand
	{
		public User NewUser { get; }

		public SignUpInsertNewUserCommand(User newUser)
		{
			NewUser = newUser;
		}
	}
}
