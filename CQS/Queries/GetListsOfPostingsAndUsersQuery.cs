using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;

namespace TaskHeroes.CQS.Queries
{
	public class GetListsOfPostingsAndUsersQuery : IQuery<Tuple<List<Posting>, List<User>>>
	{
	}
}
