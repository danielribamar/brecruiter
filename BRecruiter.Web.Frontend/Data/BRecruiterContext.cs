using BRecruiter.Web.Frontend.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace BRecruiter.Web.Frontend.Data
{
    public class BRecruiterContext : DbContext
    {
        public BRecruiterContext(DbContextOptions<BRecruiterContext> options)
        : base(options)
        { }

        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Skill>().ToTable("brecruiter_skills");
            modelBuilder.Entity<Skill>().HasKey(pk => pk.Id);
        }
    }
}
