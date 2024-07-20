using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Web.Models
{
    public class CategoryProject
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int ProjectId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public Project? Project { get; set; }
    }
}
