using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace imperugo.aspnet.core.training.Models
{
    public class BlogDbContext : IdentityDbContext<User>
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTags>().HasKey(m => new { m.PostId, m.TagId });
            base.OnModelCreating(modelBuilder);
        }

        public async Task EnsureSeedData(UserManager<User> userManager)
        {
            if (this. AllMigrationsApplied())
            {
                if (!this.Users.Any())
                {                    
                    await userManager.CreateAsync(new User { UserName = "super" }, "Pa$$w0rd");
                }
            }
        }

        protected bool AllMigrationsApplied()
        { 
            var applied = this.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = this.GetService<IMigrationsAssembly>() 
                .Migrations 
                .Select(m => m.Key);

            return !total.Except(applied).Any(); 
        }

    public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
