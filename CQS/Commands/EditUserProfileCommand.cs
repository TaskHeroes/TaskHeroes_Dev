using TaskHeroes.CQSInterfaces;

namespace TaskHeroes.CQS.Commands
{
	public class EditUserProfileCommand : ICommand
	{
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Description { get; set; }

        public EditUserProfileCommand(int userId, string firstName, string lastName, string email, string city, string province, string description)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            City = city;
            Province = province;
            Description = description;
        }
    }
}
