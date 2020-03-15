using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskHeroes.Data;

namespace TaskHeroes.CQS.TransportObjects
{
	public class UserFullData
	{
		public User User { get; }
		public decimal Rating { get; }
		public List<Data.Task> TaskHistory { get; }
		public List<Data.Task> ListOfPostingsBeingOffered { get; set; }

		public UserFullData(User user, decimal rating, List<Data.Task> taskHistory, List<Data.Task> listOfPostingsBeingOffered)
		{
			User = user;
			Rating = rating;
			TaskHistory = taskHistory;
			ListOfPostingsBeingOffered = listOfPostingsBeingOffered;
		}
	}
}
