using System;
using System.Collections.Generic;
using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;

namespace TaskHeroes.CQS.Queries
{
	public class GetListsOfPostingsAndUsersQuery : IQuery<Tuple<List<Data.Task>, List<User>>>
	{
	}
}
