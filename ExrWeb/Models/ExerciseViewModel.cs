using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExrWeb.Models
{
	public class ExerciseViewModel
	{
		public Exercise Exr { get; set; }
		public IEnumerable<SelectListItem> MachineTypes { get; set; }
	}
}