using System;
using System.Collections.Generic;
using TaskHeroes.Data;

namespace TaskHeroes.Models
{
    public class UserProfileModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        // ListOfInterestingTasks is the list of postings that the user is interested in
        public List<Task> ListOfInterestingTasks { get; set; }
        // ListOfPostingsBeingOffered is the list of postings the user is currently offering
        public List<Task> ListOfPostingsBeingOffered { get; set; }
        public DateTime DateCreated { get; set; }
        public bool AllowEditProfile { get; set; }
        public string Image { get; set; }
    }
}
