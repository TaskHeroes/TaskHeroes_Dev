using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskHeroes.CQS.Commands;
using TaskHeroes.CQS.Queries;
using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;
using TaskHeroes.Models;

namespace TaskHeroes.Controllers
{
    public class LoginController : Controller
    {
        private readonly IQueryHandler<GetUserByUsernameAndPasswordQuery, User> _getUserByUsernameAndPasswordQueryHandler;
        private readonly ICommandHandler<SignUpInsertNewUserCommand> _signUpInsertNewUserCommandHandler;

        public LoginController(
            IQueryHandler<GetUserByUsernameAndPasswordQuery, User> getUserByUsernameAndPasswordQueryHandler,
            ICommandHandler<SignUpInsertNewUserCommand> signUpInsertNewUserCommandHandler)
        {
            _getUserByUsernameAndPasswordQueryHandler = getUserByUsernameAndPasswordQueryHandler;
            _signUpInsertNewUserCommandHandler = signUpInsertNewUserCommandHandler;
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
            var existingUser = _getUserByUsernameAndPasswordQueryHandler.Handle(new GetUserByUsernameAndPasswordQuery(model.Username, model.Password));

            if (existingUser != null)
            {
                HttpContext.Session.SetInt32("userid", existingUser.Id);
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
            var existingUser = _getUserByUsernameAndPasswordQueryHandler.Handle(new GetUserByUsernameAndPasswordQuery(model.Username, model.Password));

            if (existingUser != null)
            {
                HttpContext.Session.SetInt32("userid", existingUser.Id);
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

            _signUpInsertNewUserCommandHandler.Handle(new SignUpInsertNewUserCommand(userForInsert));

            return RedirectToAction("Index", "Home");
        }
    }
}