using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskHeroes.Data;
using TaskHeroes.Models;

namespace TaskHeroes.Controllers
{
    public class LoginController : Controller
    {
        private readonly TaskHeroesDbContext _context;
        public LoginController(TaskHeroesDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginForTaskSeeker(LoginModel model)
        {
            var existingUser = _context.Users.FirstOrDefault(user => user.Username == model.Username && user.Password == model.Password);

            if (existingUser != null)
            {
                HttpContext.Session.SetInt32("userid", 123);
                HttpContext.Session.SetString("username", model.Username);
                HttpContext.Session.SetInt32("usertype", 1); // 1= Task Seeker, 2 = Task Offerer

                return RedirectToAction("Index", "Home");
            }
            else
            {
                // TODO: handle wrong username/password
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult LoginForTaskOfferer(LoginModel model)
        {
            var existingUser = _context.Users.FirstOrDefault(user => user.Username == model.Username && user.Password == model.Password);

            if (existingUser != null)
            {
                HttpContext.Session.SetInt32("userid", 123);
                HttpContext.Session.SetString("username", model.Username);
                HttpContext.Session.SetInt32("usertype", 2); // 1= Task Seeker, 2 = Task Offerer

                return RedirectToAction("Index", "Home");
            }
            else
            {
                // TODO: handle wrong username/password
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult SubmitSignUp(SignUpModel model)
        {
            var userForInsert = new User();
            userForInsert.Email = model.Email;
            userForInsert.Username = model.Username;
            userForInsert.Password = model.Password;
            userForInsert.Id = _context.Users.Any() ? _context.Users.Max(x => x.Id) + 1 : 1;

            _context.Users.Add(userForInsert);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}