using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskHeroes.Data;

namespace TaskHeroes.Models
{
	public class HomeModel
	{
		public List<Data.Task> ListOfPostings { get; set; }
		public List<User> ListOfUsers { get; set; }
	}
}
