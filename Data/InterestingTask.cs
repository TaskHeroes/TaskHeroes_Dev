using System.ComponentModel.DataAnnotations.Schema;

namespace TaskHeroes.Data
{
	public class InterestingTask
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int UserId { get; set; }
		public int TaskId { get; set; }
	}
}
