using Microsoft.EntityFrameworkCore;

namespace MyBlog.Web.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(){}

        public BlogContext(DbContextOptions<BlogContext> options) 
            : base(options ) { }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MainPage> MainPages { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<ContactMessage> ContactMessage { get; set; }
        public DbSet<Article> Articles { get; set; }
		public DbSet<Assignment> Assignments { get; set; }
		public DbSet<Project> Projects { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<ArticleTag> ArticleTag { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProject> CategoryProject { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
            "Server=EMRULLAH\\SQLEXPRESS;Database=BlogDb;" +
            "TrustServerCertificate=True;Trusted_Connection=True;"
               );
            }
           
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //ÇOKA ÇOK İLİŞKİ İÇİN
        {
            modelBuilder.Entity<ArticleTag>()
                .HasKey(x => new { x.ArticleId, x.TagId });
            modelBuilder.Entity<CategoryProject>()
               .HasKey(x => new { x.CategoryId, x.ProjectId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
