﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Web.Models
{
	public class Assignment
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public int ProjectId { get; set; }
		[ForeignKey("ProjectId")]
		public virtual Project Project { get; set; }
		[Required]
		[StringLength(64)]
		public string Title { get; set; }
		public string Description { get; set; }
		public bool Status { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime DeadLine { get; set; }
	}
}
