using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExrWeb.Models
{
	public class Exercise
	{
		static int s_id = 0;

		public Exercise()
		{
			s_id++;
			ID = s_id;
		}

		public int ID { get; set; }

		//[Required(ErrorMessage ="Invalid machine")]
		//[Required]
		public string Machine { get; set; }

		//[Required(ErrorMessage = "Invalid # reps")]
		//[Required]
		public int NumReps { get; set; }

		//[Required]
		public DateTime ExDate { get; set; }
	}
}