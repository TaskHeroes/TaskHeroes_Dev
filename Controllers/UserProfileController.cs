using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public UserProfileController(IQueryHandler<GetUserDataByUserIdQuery, UserFullData> getUserByUserIdQueryHandler)
        {
            _getUserByUserIdQueryHandler = getUserByUserIdQueryHandler;
        }

        // GET: UserProfile
        public ActionResult Index()
        {
            // Pull up the information of the logged in user
            var userFullData = _getUserByUserIdQueryHandler.Handle(new GetUserDataByUserIdQuery(HttpContext.Session.GetInt32("userid").Value));

            var userModel = new UserProfileModel();
            userModel.UserId = userFullData.User.Id;
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

            return View(userModel);
        }

        // GET: UserProfile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProfile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserProfile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserProfile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserProfile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserProfile/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}