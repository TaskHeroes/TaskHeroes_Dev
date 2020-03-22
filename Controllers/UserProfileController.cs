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

        // GET: UserProfile
        public ActionResult Index()
        {
            return UserDetails(HttpContext.Session.GetInt32("userid").Value);
        }

        public ActionResult EditUserProfile(UserProfileModel model)
        {
            _editUserProfileCommandHandler.Handle(new EditUserProfileCommand(HttpContext.Session.GetInt32("userid").Value, model.FirstName, model.LastName, model.Email, model.City, model.Province, model.Description));

            return RedirectToAction("Index");
        }

        // Endpoint: /UserProfile/UserCard?id=1
        // TO USE: asp-controller="UserProfile" asp-action="UserCard" asp-route-id=@item.Id
        public ActionResult UserCard(int id)
        {
            // Pull up the information of the logged in user
            var userFullData = _getUserByUserIdQueryHandler.Handle(new GetUserDataByUserIdQuery(id));

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
            userModel.AllowEditProfile = false;
            userModel.Image = userFullData.User.Image;

            return View(userModel);
        }

        // Endpoint: /UserProfile/UserDetails?id=1 OR /UserProfile/UserDetails/1
        // TO USE: asp-controller="UserProfile" asp-action="UserDetails" asp-route-id=@item.Id
        public ActionResult UserDetails(int id)
        {
            // Pull up the information of the logged in user
            var userFullData = _getUserByUserIdQueryHandler.Handle(new GetUserDataByUserIdQuery(id));

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
            userModel.AllowEditProfile = HttpContext.Session.GetInt32("userid").HasValue && id == HttpContext.Session.GetInt32("userid").Value;
            userModel.Image = userFullData.User.Image;

            return View(userModel);
        }
    }
}