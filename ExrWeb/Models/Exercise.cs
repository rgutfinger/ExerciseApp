using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExrWeb.Models
{
	public class Exercise
	{
		[Required(ErrorMessage ="Invalid machine")]
		public string Machine { get; set; }

		[Required(ErrorMessage = "Invalid # reps")]
		public int NumReps { get; set; }

		[Required]
		public DateTime ExDate { get; set; }
	}
}