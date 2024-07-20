using System.ComponentModel.DataAnnotations;

namespace MyBlog.Web.Models
{
	public class Project
	{
		public Project() 
		{ 
			this.Assignments = new HashSet<Assignment>();
		}

		[Key] 
		public int Id { get; set; }
		[Required] 
		public string Name { get; set; }
		public string? ImageUrl { get; set; }
		[Required] 
		public string Description { get; set; }
		public bool Status { get; set; }
		public DateTime CreatedDate { get; set; }
		public ICollection<Assignment> Assignments { get; set; }
	}
}
