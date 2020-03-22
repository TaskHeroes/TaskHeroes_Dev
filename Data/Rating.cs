using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskHeroes.Data
{
	public class Rating
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int RatingTotal { get; set; }
		public int NumberOfRatings { get; set; }
	}
}
