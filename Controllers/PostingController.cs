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
	public class PostingController : Controller
	{
		private readonly TaskHeroesDbContext _context;
		public PostingController(TaskHeroesDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
