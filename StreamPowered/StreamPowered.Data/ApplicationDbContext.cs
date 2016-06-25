using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using StreamPowered.Data.Migrations;
using StreamPowered.Models;

namespace StreamPowered.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<Genre> Genres { get; set; }

        public IDbSet<Rating> Ratings { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public IDbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
