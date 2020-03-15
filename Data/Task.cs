using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskHeroes.Data
{
	public class Task
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string JobType { get; set; }
		public decimal MoneyOffer { get; set; }
		public decimal WorkPeriod { get; set; }
		public int OffererId { get; set; }
	}
}
