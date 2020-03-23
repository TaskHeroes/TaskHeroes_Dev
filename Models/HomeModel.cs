using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskHeroes.Data;

namespace TaskHeroes.Models
{
	// Home Model for Home view
	public class HomeModel
	{
		// List of all Postings
		public List<Data.Task> ListOfPostings { get; set; }

		// List of all Users
		public List<User> ListOfUsers { get; set; }
	}
}
