using ExrWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExrWeb.Controllers
{
    public class ExerciseController : Controller
    {
		static List<Exercise> m_elist = new List<Exercise>();

		// GET: Exercise
		public ActionResult Index()
        {
            return View(new Exercise());
        }

		public ActionResult Add(Exercise model)
		{
			ViewBag.Title = "Exercise";

			//this.ModelState.

			m_elist.Add(model);

			return View("Index", model);
		}

		public ActionResult List()
		{
			return View(m_elist);
		}


	}
}