using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskHeroes.CQS.Commands;
using TaskHeroes.CQS.Queries;
using TaskHeroes.CQSInterfaces;
using TaskHeroes.Data;
using TaskHeroes.Models;

namespace TaskHeroes.Controllers
{
    public class TaskDetailController : Controller
    {
        private readonly ICommandHandler<InsertNewTaskCommand> _insertNewTaskCommandHandler;
        private readonly IQueryHandler<GetTaskByIdQuery, Task> _getTaskByIdQueryHandler;
        private readonly ICommandHandler<InsertInterestingTaskCommand> _insertInterestingTaskCommandHandler;
        public TaskDetailController(
            ICommandHandler<InsertNewTaskCommand> insertNewTaskCommandHandler,
            IQueryHandler<GetTaskByIdQuery, Task> getTaskByIdQueryHandler,
            ICommandHandler<InsertInterestingTaskCommand> insertInterestingTaskCommandHandler)
        {
            _insertNewTaskCommandHandler = insertNewTaskCommandHandler;
            _getTaskByIdQueryHandler = getTaskByIdQueryHandler;
            _insertInterestingTaskCommandHandler = insertInterestingTaskCommandHandler;
        }

        public ActionResult Index()
        {
            return View();
        }
        
        // Task Card view
        public ActionResult TaskCard(int id)
        {
            // Get task by TaskId
            var task = _getTaskByIdQueryHandler.Handle(new GetTaskByIdQuery(id));

            // Create and match the data from Task to TaskDetailModel
            var taskModel = new TaskDetailModel();
            taskModel.Id = task.Id;
            taskModel.Title = task.Title;
            taskModel.Description = task.Description;
            taskModel.JobType = task.JobType;
            taskModel.MoneyOffer = task.MoneyOffer;
            taskModel.WorkPeriod = task.WorkPeriod;
            taskModel.OffererId = task.OffererId;

            // Return TaskCard view with the corresponding model
            return View("TaskCard",taskModel);
        }
        
        // GET: TaskDetail/Details/5
        public ActionResult Details(int id)
        {
            // Get task by TaskId
            var task = _getTaskByIdQueryHandler.Handle(new GetTaskByIdQuery(id));

            // Create and match the data from Task to TaskDetailModel
            var taskModel = new TaskDetailModel();
            taskModel.Id = task.Id;
            taskModel.Title = task.Title;
            taskModel.Description = task.Description;
            taskModel.JobType = task.JobType;
            taskModel.MoneyOffer = task.MoneyOffer;
            taskModel.WorkPeriod = task.WorkPeriod;
            taskModel.OffererId = task.OffererId;

            // Return Details view with the corresponding model
            return View(taskModel);
        }

        // Task Create view
        public ActionResult TaskCreate()
        {
            return View();
        }

        // Create Task action
        [HttpPost]
        public ActionResult Create(TaskDetailModel model)
        {
            // Insert the new task into the database
            _insertNewTaskCommandHandler.Handle(new InsertNewTaskCommand(model.Title, model.Description, model.JobType, model.MoneyOffer, model.WorkPeriod, HttpContext.Session.GetInt32("userid").Value));

            // Redirect to User Profile page so user can view the new task in there list of offered postings
            return RedirectToAction("Index", "UserProfile");
        }

        // Interest Button Click action
        public ActionResult InterestButtonClick(int id)
        {
            // Get the Id of the logged in user
            var loggedInUserId = HttpContext.Session.GetInt32("userid");

            // If user is logged in, insert the new interesting task into the database so that it will show up in User Profile for review
            if (loggedInUserId != null)
                _insertInterestingTaskCommandHandler.Handle(new InsertInterestingTaskCommand(loggedInUserId.Value, id));

            // Redirect to Home page
            return RedirectToAction("Index", "Home");
        }
    }
}