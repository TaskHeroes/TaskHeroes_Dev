using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskHeroes.Controllers
{
    public class TaskDetailController : Controller
    {
        // GET: TaskDetail
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TaskCard()
        {
            return View();
        }
        public ActionResult TaskCreate()
        {
            return View();
        }
        // GET: TaskDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaskDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskDetail/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaskDetail/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaskDetail/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}