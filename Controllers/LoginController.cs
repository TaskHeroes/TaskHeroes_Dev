using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskHeroes.Models;

namespace TaskHeroes.Controllers
{
    public class LoginController : Controller
    {
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
            HttpContext.Session.SetInt32("userid", 123);
            HttpContext.Session.SetString("username", model.Username);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult LoginForTaskOfferer(LoginModel model)
        {
            HttpContext.Session.SetInt32("userid", 123);
            HttpContext.Session.SetString("username", model.Username);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult SubmitSignUp(SignUpModel model)
        {
            var testId = HttpContext.Session.GetInt32("userid");
            var testUsername = HttpContext.Session.GetString("username");
            return RedirectToAction("Index", "Home");
        }
    }
}