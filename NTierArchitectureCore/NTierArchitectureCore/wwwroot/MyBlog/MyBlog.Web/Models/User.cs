using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Web.Models
{
	public class User
	{
		[Key] 
		public Guid Id { get; set; }
		[Required] 
		public int RoleId { get; set; }
		[ForeignKey("RoleId")]
		public virtual Role? Role { get; set; }
		[Required, StringLength(100)] 
		public string Email { get; set; }
		[Required] 
		public string Password { get; set; }
		[Required, StringLength(32)] 
		public string UserName { get; set; }
		[Required, StringLength(64)] 
		public string FullName { get; set; }
		[StringLength(128)] public string? ImageUrl { get; set; }
		public DateTime CreatedDate { get; set; }
		public bool Status { get; set; }
		public bool? Deleted { get; set; }
	}
}
