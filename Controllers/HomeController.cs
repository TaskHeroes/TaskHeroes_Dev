using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskHeroes.CQS.Queries;
using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;
using TaskHeroes.Models;

namespace TaskHeroes.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQueryHandler<GetListsOfPostingsAndUsersQuery, Tuple<List<Task>, List<User>>> _getListsOfPostingsAndUsersQueryHandler;

        public HomeController(ILogger<HomeController> logger, IQueryHandler<GetListsOfPostingsAndUsersQuery, Tuple<List<Task>, List<User>>> getListsOfPostingsAndUsersQueryHandler)
        {
            _getListsOfPostingsAndUsersQueryHandler = getListsOfPostingsAndUsersQueryHandler;
        }

        // Home Page: Get lists of posting and users and display them as cards
        public IActionResult Index()
        {
            var modelForView = new HomeModel();
            var queryResult = _getListsOfPostingsAndUsersQueryHandler.Handle(new GetListsOfPostingsAndUsersQuery());
            modelForView.ListOfPostings = queryResult.Item1;
            modelForView.ListOfUsers = queryResult.Item2;

            return View("Index", modelForView);
        }

        // Login action - Redirect to login page
        public IActionResult Login()
        {
            return RedirectToAction("Index", "Login");
        }

        // Signup action - Redirect to signup page
        public IActionResult Signup()
        {
            return RedirectToAction("SignUp", "Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Sign out action - clear session variables
        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return Index();
        }

        // Post a task action - Redirect to Create Task view
        public IActionResult PostATask()
        {
            return RedirectToAction("TaskCreate", "TaskDetail");
        }
        
        // View user profile action - Redirect to User Profile page
        public IActionResult ViewUserProfile()
        {
            return RedirectToAction("Index", "UserProfile");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
