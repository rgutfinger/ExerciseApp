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

		[HttpPost]
		public ActionResult Add(Exercise model)
		{
			ViewBag.Title = "Exercise";

			//next --   but iisExpress doesn't debug 
			// ***turn off JScript dbg
			// update to vs15.3 and above
			// or set breakpoint in code
			// usee localhost (=iis?) but can't security refs top dir...

			if (string.IsNullOrWhiteSpace(model.Machine))
				ModelState.AddModelError("Machine", "Machine name missing");
			if (model.NumReps <= 0)
				ModelState.AddModelError("NumReps", "NumReps must be positive");
			if (model.ExDate <= new DateTime(2018, 1, 1))
				ModelState.AddModelError("ExDate", "Invalid date");

			if (ModelState.IsValid)
			{
				m_elist.Add(model);

				return View("Index", model);
			}
			else
			{
				ViewBag.Error = "Invalid args";
				return View("Index", null);
			}
		}

		public ActionResult List()
		{
			return View(m_elist);
		}

		public ActionResult Delete(string machine)
		{
			Exercise ex = m_elist.Find(e => e.Machine.Equals(machine, StringComparison.InvariantCultureIgnoreCase));
			m_elist.Remove(ex);

			return View("List", m_elist);
		}

		public ActionResult Edit(string machine)
		{
			Exercise ex = m_elist.Find(e => e.Machine.Equals(machine, StringComparison.InvariantCultureIgnoreCase));
			//m_elist.Remove(ex);

			//return View("Edit", ex);
			return View("Edit", ex);
		}

		[HttpPost]
		public ActionResult Edit(Exercise model)
		{
			Exercise ex = m_elist.Find(e => e.Machine.Equals(model.Machine, StringComparison.InvariantCultureIgnoreCase));
			ex.NumReps = model.NumReps;
			ex.ExDate = model.ExDate;

			return View("List", m_elist);
		}
	}
}