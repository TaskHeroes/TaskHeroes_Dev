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

        // Main login page
        public ActionResult Index()
        {
            return View();
        }

        // Signup action - Return Signup view
        public ActionResult SignUp()
        {
            return View();
        }

        // Login for Task Seeker action
        [HttpPost]
        public ActionResult LoginForTaskSeeker(LoginModel model)
        {
            // Get existing user by Username and Password
            var existingUser = _getUserByUsernameAndPasswordQueryHandler.Handle(new GetUserByUsernameAndPasswordQuery(model.Username, model.Password));

            if (existingUser != null)
            {
                // If there is a match, perform login by setting three session variables userid, username and usertype.
                // These session variables can be used to identify login status and logged in user.
                HttpContext.Session.SetInt32("userid", existingUser.Id);
                HttpContext.Session.SetString("username", model.Username);
                HttpContext.Session.SetInt32("usertype", 1); // 1= Task Seeker, 2 = Task Offerer

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // Login for Task Offerer action
        [HttpPost]
        public ActionResult LoginForTaskOfferer(LoginModel model)
        {
            // Get existing user by Username and Password
            var existingUser = _getUserByUsernameAndPasswordQueryHandler.Handle(new GetUserByUsernameAndPasswordQuery(model.Username, model.Password));

            if (existingUser != null)
            {
                // If there is a match, perform login by setting three session variables userid, username and usertype.
                // These session variables can be used to identify login status and logged in user.
                HttpContext.Session.SetInt32("userid", existingUser.Id);
                HttpContext.Session.SetString("username", model.Username);
                HttpContext.Session.SetInt32("usertype", 2); // 1= Task Seeker, 2 = Task Offerer

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // Submit Sign Up action
        [HttpPost]
        public ActionResult SubmitSignUp(SignUpModel model)
        {
            // Create a new User and set email, username and password correspondingly.
            var userForInsert = new User();
            userForInsert.Email = model.Email;
            userForInsert.Username = model.Username;
            userForInsert.Password = model.Password;

            // Insert the new user to the database
            _signUpInsertNewUserCommandHandler.Handle(new SignUpInsertNewUserCommand(userForInsert));

            // Redirect to Login page
            return RedirectToAction("Index", "Login");
        }
    }
}