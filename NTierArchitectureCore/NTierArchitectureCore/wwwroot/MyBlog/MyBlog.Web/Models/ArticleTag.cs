using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Web.Models
{
    public class ArticleTag
    {
        [Required] 
        public int ArticleId { get; set; }
        [Required]
        public int TagId { get; set; }

        [ForeignKey(nameof(ArticleId))]
        public Article? Article { get; set; }
        [ForeignKey(nameof(TagId))]
        public Tag? Tag { get; set; }
    }
}
