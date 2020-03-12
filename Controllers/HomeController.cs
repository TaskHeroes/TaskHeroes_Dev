using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskHeroes.Data;
using TaskHeroes.Models;

namespace TaskHeroes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TaskHeroesDbContext _context;

        public HomeController(ILogger<HomeController> logger, TaskHeroesDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var modelForView = new HomeModel();
            modelForView.ListOfPostings = _context.Postings.ToList();
            modelForView.ListOfUsers = _context.Users.ToList();

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
