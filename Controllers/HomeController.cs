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
        private readonly ILogger<HomeController> _logger;
        private readonly IQueryHandler<GetListsOfPostingsAndUsersQuery, Tuple<List<Posting>, List<User>>> _getListsOfPostingsAndUsersQueryHandler;

        public HomeController(ILogger<HomeController> logger, IQueryHandler<GetListsOfPostingsAndUsersQuery, Tuple<List<Posting>, List<User>>> getListsOfPostingsAndUsersQueryHandler)
        {
            _logger = logger;
            _getListsOfPostingsAndUsersQueryHandler = getListsOfPostingsAndUsersQueryHandler;
        }

        public IActionResult Index()
        {
            var modelForView = new HomeModel();
            var queryResult = _getListsOfPostingsAndUsersQueryHandler.Handle(new GetListsOfPostingsAndUsersQuery());
            modelForView.ListOfPostings = queryResult.Item1;
            modelForView.ListOfUsers = queryResult.Item2;

            return View(modelForView);
        }

        public IActionResult Login()
        {
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Signup()
        {
            return RedirectToAction("SignUp", "Login");
        }

        public void Search()
        {
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
