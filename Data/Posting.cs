using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskHeroes.Data
{
	public class Posting
	{

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int OffererId { get; set; }
		public string Description { get; set; }
		public int CategoryId { get; set; }
		public bool Occupied { get; set; }
		public int JobTypeId { get; set; }
	}
}
