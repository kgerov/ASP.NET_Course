using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Snippy.Models;
using Snippy.Data.Migrations;

namespace Snippy.Data
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


        public IDbSet<Snippet> Snippets { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Language> Languages { get; set; }

        public IDbSet<Label> Labels { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
