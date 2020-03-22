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
		public List<Data.Task> ListOfInterestingTasks { get; }
		public List<Data.Task> ListOfPostingsBeingOffered { get; set; }

		public UserFullData(User user, List<Data.Task> listOfInterestingTasks, List<Data.Task> listOfPostingsBeingOffered)
		{
			User = user;
			ListOfInterestingTasks = listOfInterestingTasks;
			ListOfPostingsBeingOffered = listOfPostingsBeingOffered;
		}
	}
}
