using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskHeroes.Data
{
	public class User
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Username {get; set;}
		public string Password { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string City { get; set; }
		public string Province { get; set; }
		public string Description { get; set; }
		public DateTime DateCreated { get; set; }
		public decimal Rating { get; set; }
		public string Image { get; set; }
	}
}
