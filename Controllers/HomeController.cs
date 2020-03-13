using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IQueryHandler<GetListsOfPostingsAndUsersQuery, Tuple<List<Posting>, List<User>>> _queryHandler;

        public HomeController(ILogger<HomeController> logger, IQueryHandler<GetListsOfPostingsAndUsersQuery, Tuple<List<Posting>, List<User>>> queryHandler)
        {
            _logger = logger;
            _queryHandler = queryHandler;
        }

        public IActionResult Index()
        {
            var modelForView = new HomeModel();

            var tupleThing = _queryHandler.Handle(new GetListsOfPostingsAndUsersQuery());

            modelForView.ListOfPostings = tupleThing.Item1;
            modelForView.ListOfUsers = tupleThing.Item2;

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
