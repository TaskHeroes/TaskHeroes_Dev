using TaskHeroes.CQS.TransportObjects;
using TaskHeroes.CQSInterfaces;

namespace TaskHeroes.CQS.Queries
{
	public class GetUserDataByUserIdQuery : IQuery<UserFullData>
	{
		public int UserId { get; }
		public GetUserDataByUserIdQuery(int userId)
		{
			UserId = userId;
		}
	}
}
