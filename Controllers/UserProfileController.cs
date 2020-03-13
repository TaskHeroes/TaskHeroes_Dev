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
            var user = _getUserByUserIdQueryHandler.Handle(new GetUserDataByUserIdQuery(HttpContext.Session.GetInt32("userid").Value));

            var userModel = new UserProfileModel();
            userModel.UserId = user.Id;
            userModel.Username = user.Username;
            userModel.Password = user.Password;
            userModel.FirstName = user.FirstName;
            userModel.LastName = user.LastName;
            userModel.City = user.City;
            userModel.Province = user.Province;
            userModel.Description = user.Description;

            // TODO: Grab and map Rating, Task History and List of offered postings as well!!

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