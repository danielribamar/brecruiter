using BRecruiter.Web.Frontend.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace BRecruiter.Web.Frontend.Data
{
    public class BRecruiterContext : DbContext
    {
        public BRecruiterContext(DbContextOptions<BRecruiterContext> options)
        : base(options)
        {

        }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<CandidateSkill> CandidateSkills { get; set; }

        public DbSet<List> Lists { get; set; }
        public DbSet<CandidateList> CandidateLists { get; set; }

        public DbSet<College> Colleges { get; set; }
        public DbSet<CandidateCollege> CandidateCollege { get; set; }

        //public DbSet<CandidateUpdate> CandidateUpdates { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Candidate>().ToTable("brecruiter_candidates");
            modelBuilder.Entity<Candidate>().HasKey(pk => pk.Id);

            modelBuilder.Entity<Skill>().ToTable("brecruiter_skills");
            modelBuilder.Entity<CandidateSkill>().ToTable("brecruiter_candidateSkills");
            modelBuilder.Entity<CandidateSkill>().HasKey(p => new { p.CandidateId, p.SkillId });

            modelBuilder.Entity<CandidateList>().HasKey(pk => new { pk.CandidateId, pk.ListId });

            modelBuilder.Entity<College>().ToTable("brecruiter_colleges");
            modelBuilder.Entity<CandidateCollege>().ToTable("brecruiter_candidateCollege");
            modelBuilder.Entity<CandidateCollege>().HasKey(p => new { p.CandidateId, p.Collegeid });

        }
    }
}
