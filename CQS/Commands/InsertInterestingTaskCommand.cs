using TaskHeroes.CQSInterfaces;

namespace TaskHeroes.CQS.Commands
{
	public class InsertInterestingTaskCommand : ICommand
	{
		public int UserId { get; set; }
		public int TaskId { get; set; }

		public InsertInterestingTaskCommand(int userId, int taskId)
		{
			UserId = userId;
			TaskId = taskId;
		}
	}
}
