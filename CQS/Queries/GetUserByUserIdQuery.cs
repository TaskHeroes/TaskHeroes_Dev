using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;

namespace TaskHeroes.CQS.Queries
{
	public class GetUserByUserIdQuery : IQuery<User>
	{
		public int UserId { get; }
		public GetUserByUserIdQuery(int userId)
		{
			UserId = userId;
		}
	}
}
