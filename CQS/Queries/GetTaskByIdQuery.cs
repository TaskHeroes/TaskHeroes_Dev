using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;

namespace TaskHeroes.CQS.Queries
{
	public class GetTaskByIdQuery : IQuery<Task>
	{
		public int TaskId { get; }
		public GetTaskByIdQuery(int taskId)
		{
			TaskId = taskId;
		}
	}
}
