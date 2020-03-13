using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;

namespace TaskHeroes.CQS.Queries
{
	public class GetUserByUsernameAndPasswordQuery : IQuery<User>
	{
		public string Username { get; }
		public string Password { get; }

		public GetUserByUsernameAndPasswordQuery(string username, string password)
		{
			Username = username;
			Password = password;
		}
	}
}
