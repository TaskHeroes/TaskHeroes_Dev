using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskHeroes.CQS.Commands;
using TaskHeroes.CQS.Queries;
using TaskHeroes.CQS.TransportObjects;
using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;
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
            userModel.Rating = userFullData.Rating;
            userModel.TaskHistory = userFullData.TaskHistory;
            userModel.ListOfPostingsBeingOffered = userFullData.ListOfPostingsBeingOffered;
            userModel.DateCreated = userFullData.User.DateCreated;

            return View(userModel);
        }

        // GET: UserProfile
        public ActionResult Index()
        {
            // Pull up the information of the logged in user
            var userFullData = _getUserByUserIdQueryHandler.Handle(new GetUserDataByUserIdQuery(HttpContext.Session.GetInt32("userid").Value));

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
            userModel.Rating = userFullData.Rating;
            userModel.TaskHistory = userFullData.TaskHistory;
            userModel.ListOfPostingsBeingOffered = userFullData.ListOfPostingsBeingOffered;
            userModel.DateCreated = userFullData.User.DateCreated;

            return View(userModel);
        }

        public ActionResult EditUserProfile(UserProfileModel model)
        {
            _editUserProfileCommandHandler.Handle(new EditUserProfileCommand(model.UserId, model.Username, model.Password, model.FirstName, model.LastName, model.Email, model.City, model.Province, model.Description));

            return Index();
        }
    }
}