using Model.Models.Mapping;
using System.Data.Entity;

namespace Model.Models
{
    public partial class BlogExContext : DbContext
    {
        static BlogExContext()
        {
            Database.SetInitializer<BlogExContext>(null);
        }

        public BlogExContext()
            : base("Name=BlogExContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new PostMap());
        }
    }
}
