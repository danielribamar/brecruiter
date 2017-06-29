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
        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Skill>().ToTable("brecruiter_skills");
            modelBuilder.Entity<Skill>().HasKey(pk => pk.Id);

            modelBuilder.Entity<Candidate>().ToTable("brecruiter_candidates");
            modelBuilder.Entity<Candidate>().HasKey(pk => pk.Id);
        }
    }
}
