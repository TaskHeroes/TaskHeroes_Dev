using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskHeroes.Models
{
	public class PostingModel
	{
		public int Id { get; set; }
		public int OffererId { get; set; }
		public string Description { get; set; }
		public int CategoryId { get; set; }
		public bool Occupied { get; set; }
		public int JobTypeId { get; set; }
	}
}
