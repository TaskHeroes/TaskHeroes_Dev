using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET: TaskDetail
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult TaskCard(int id)
        {
            var task = _getTaskByIdQueryHandler.Handle(new GetTaskByIdQuery(id));
            var taskModel = new TaskDetailModel();
            taskModel.Id = task.Id;
            taskModel.Title = task.Title;
            taskModel.Description = task.Description;
            taskModel.JobType = task.JobType;
            taskModel.MoneyOffer = task.MoneyOffer;
            taskModel.WorkPeriod = task.WorkPeriod;
            taskModel.OffererId = task.OffererId;

            return View("TaskCard",taskModel);
        }
        
        // GET: TaskDetail/Details/5
        public ActionResult Details(int id)
        {
            var task = _getTaskByIdQueryHandler.Handle(new GetTaskByIdQuery(id));
            var taskModel = new TaskDetailModel();
            taskModel.Id = task.Id;
            taskModel.Title = task.Title;
            taskModel.Description = task.Description;
            taskModel.JobType = task.JobType;
            taskModel.MoneyOffer = task.MoneyOffer;
            taskModel.WorkPeriod = task.WorkPeriod;
            taskModel.OffererId = task.OffererId;

            return View(taskModel);
        }

        public ActionResult TaskCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TaskDetailModel model)
        {
            _insertNewTaskCommandHandler.Handle(new InsertNewTaskCommand(model.Title, model.Description, model.JobType, model.MoneyOffer, model.WorkPeriod, HttpContext.Session.GetInt32("userid").Value));

            return RedirectToAction("Index", "UserProfile");
        }

        public ActionResult InterestButtonClick(int id)
        {
            var loggedInUserId = HttpContext.Session.GetInt32("userid");

            if (loggedInUserId != null)
                _insertInterestingTaskCommandHandler.Handle(new InsertInterestingTaskCommand(loggedInUserId.Value, id));

            return RedirectToAction("Index", "Home");
        }
    }
}