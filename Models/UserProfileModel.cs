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
        // TaskHistory is the list of postings that the user completed before
        public List<Posting> TaskHistory { get; set; }
        // ListOfPostingsBeingOffered is the list of postings the user is currently offering
        public List<Posting> ListOfPostingsBeingOffered { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
