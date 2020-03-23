using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskHeroes.Models
{
    // Task Detail model for task-related views and actions
    public class TaskDetailModel
    {
        // Task Id (for saving into the database)
        public int Id { get; set; }

        // Title of the job being offered
        public string Title { get; set; }

        // Detailed description of the task
        public string Description { get; set; }

        // Type of the job (Permanent/One-time/Full-Time/Part-Time)
        public string JobType { get; set; }

        // The amount of money for completing the task
        public decimal MoneyOffer { get; set; }

        // The estimated period of time required to complete the task
        public decimal WorkPeriod { get; set; }

        // UserId of the offerer user
        public int OffererId { get; set; }
    }
}
