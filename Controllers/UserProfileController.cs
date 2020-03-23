using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskHeroes.CQS.Commands;
using TaskHeroes.CQS.Queries;
using TaskHeroes.CQS.TransportObjects;
using TaskHeroes.CQSInterfaces;
using TaskHeroes.Models;

namespace TaskHeroes.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IQueryHandler<GetUserDataByUserIdQuery, UserFullData> _getUserByUserIdQueryHandler;
        private readonly ICommandHandler<EditUserProfileCommand> _editUserProfileCommandHandler;

        public UserProfileController(
            IQueryHandler<GetUserDataByUserIdQuery, UserFullData> getUserByUserIdQueryHandler,
            ICommandHandler<EditUserProfileCommand> editUserProfileCommandHandler)
        {
            _getUserByUserIdQueryHandler = getUserByUserIdQueryHandler;
            _editUserProfileCommandHandler = editUserProfileCommandHandler;
        }

        // User Profile page
        public ActionResult Index()
        {
            // Display user details by the logged in user's Id
            return UserDetails(HttpContext.Session.GetInt32("userid").Value);
        }

        // User Card view
        public ActionResult UserCard(int id)
        {
            // Pull up the information of the user by Id
            var userFullData = _getUserByUserIdQueryHandler.Handle(new GetUserDataByUserIdQuery(id));

            // Create and map data from the retrieved User to the UserProfileModel
            var userModel = new UserProfileModel();
            userModel.UserId = userFullData.User.Id;
            userModel.Email = userFullData.User.Email;
            userModel.Username = userFullData.User.Username;
            userModel.Password = userFullData.User.Password;
            userModel.FirstName = userFullData.User.FirstName;
            userModel.LastName = userFullData.User.LastName;
            userModel.City = userFullData.User.City;
            userModel.Province = userFullData.User.Province;
            userModel.Description = userFullData.User.Description;
            userModel.Rating = userFullData.User.Rating;
            userModel.ListOfInterestingTasks = userFullData.ListOfInterestingTasks;
            userModel.ListOfPostingsBeingOffered = userFullData.ListOfPostingsBeingOffered;
            userModel.DateCreated = userFullData.User.DateCreated;
            userModel.Image = userFullData.User.Image;

            // Does not allow edting profile in User Card view
            userModel.AllowEditProfile = false;

            // Return the User Card view with the corresponding model
            return View(userModel);
        }

        // User Details view
        public ActionResult UserDetails(int id)
        {
            // Pull up the information of user by Id
            var userFullData = _getUserByUserIdQueryHandler.Handle(new GetUserDataByUserIdQuery(id));

            // Create and map data from the retrieved User to the UserProfileModel
            var userModel = new UserProfileModel();
            userModel.UserId = userFullData.User.Id;
            userModel.Email = userFullData.User.Email;
            userModel.Username = userFullData.User.Username;
            userModel.Password = userFullData.User.Password;
            userModel.FirstName = userFullData.User.FirstName;
            userModel.LastName = userFullData.User.LastName;
            userModel.City = userFullData.User.City;
            userModel.Province = userFullData.User.Province;
            userModel.Description = userFullData.User.Description;
            userModel.Rating = userFullData.User.Rating;
            userModel.ListOfInterestingTasks = userFullData.ListOfInterestingTasks;
            userModel.ListOfPostingsBeingOffered = userFullData.ListOfPostingsBeingOffered;
            userModel.DateCreated = userFullData.User.DateCreated;
            userModel.Image = userFullData.User.Image;

            // Allow editing profile only if the user being retrieved is also the logged in user
            userModel.AllowEditProfile = HttpContext.Session.GetInt32("userid").HasValue && id == HttpContext.Session.GetInt32("userid").Value;

            // Return User Details view with the corresponding user model
            return View(userModel);
        }

        // Edit User Profile action
        public ActionResult EditUserProfile(UserProfileModel model)
        {
            // Update the User record in the database with new data and information
            _editUserProfileCommandHandler.Handle(new EditUserProfileCommand(HttpContext.Session.GetInt32("userid").Value, model.FirstName, model.LastName, model.Email, model.City, model.Province, model.Description));

            // Redirect to the User Profile view
            return RedirectToAction("Index");
        }
    }
}