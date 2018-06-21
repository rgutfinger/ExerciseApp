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

		MultiSelectList GetMachines(string[] selectedValues)
		{

			List<string> machines = new List<string>(
				new string[] { "bicep", "tricep", "chest" });

			machines.Sort();

			return new MultiSelectList(machines, selectedValues);

		}

		// GET: Exercise
		public ActionResult Index()
		{
			ViewBag.MachineList = GetMachines(new string[] { "bicep" });

			return View(new Exercise());
		}

		[HttpPost]
		public ActionResult Add(Exercise model)
		{
			ViewBag.Title = "Exercise";

			ViewBag.MachineList = GetMachines(new string[] { "bicep" });
			ViewBag.IsEditMode = false;

			//next --   but iisExpress doesn't debug 
			// ***turn off JScript dbg
			// update to vs15.3 and above
			// or set breakpoint in code
			// usee localhost (=iis?) but can't security refs top dir...

			ValidateModel(model);
			if (ModelState.IsValid)
			{
				model.SetID();

				m_elist.Add(model);

				return View("Index", model);
			}
			else
			{
				return View("Index", null);
			}
		}

		void ValidateModel(Exercise model)
		{
			ModelState.Clear(); // IMPORTANT: without this model values are cached in view (and ID remains 0)

			if (string.IsNullOrWhiteSpace(model.Machine))
				ModelState.AddModelError("Machine", "Machine name missing");
			if (model.NumReps <= 0)
				ModelState.AddModelError("NumReps", "NumReps must be positive");
			if (model.ExDate <= new DateTime(2018, 1, 1))
				ModelState.AddModelError("ExDate", "Invalid date");
			if (!ModelState.IsValid)
				ViewBag.Error = "Invalid args";
		}

		public ActionResult List()
		{
			return View(m_elist);
		}

		public ActionResult Delete(int id)
		{
			Exercise ex = m_elist.Find(e => e.ID==id);
			m_elist.Remove(ex);

			return View("List", m_elist);
		}

		public ActionResult Edit(int id)
		{
			Exercise ex = m_elist.Find(e => e.ID == id);
			//m_elist.Remove(ex);

			//return View("Edit", ex);

			ViewBag.Title = "Edit";
			ViewBag.MachineList = GetMachines(new string[] { ex.Machine });
			ViewBag.IsEditMode = true;

			return View("Edit", ex);
		}

		[HttpPost]
		public ActionResult Edit(Exercise model)
		{
			ValidateModel(model);
			if (ModelState.IsValid)
			{
				Exercise ex = m_elist.Find(e => e.ID == model.ID);
				ex.Machine = model.Machine;
				ex.NumReps = model.NumReps;
				ex.ExDate = model.ExDate;

				return View("List", m_elist);
			}
			else
			{
				ViewBag.Title = "Edit";
				ViewBag.MachineList = GetMachines(new string[] { model.Machine });
				ViewBag.IsEditMode = true;
				return View("Edit", model);
			}
		}
	}
}