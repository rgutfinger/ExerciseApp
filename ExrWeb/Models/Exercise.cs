using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExrWeb.Models
{
	public class Exercise
	{
		public string Machine { get; set; }
		public int NumReps { get; set; }
		public DateTime ExDate { get; set; }
	}
}