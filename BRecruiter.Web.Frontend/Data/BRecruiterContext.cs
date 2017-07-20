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
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateSkill> CandidateSkills { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<CandidateList> CandidateLists { get; set; }
        //public DbSet<CandidateUpdate> CandidateUpdates { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Candidate>().ToTable("brecruiter_candidates");
            modelBuilder.Entity<Candidate>().HasKey(pk => pk.Id);

            modelBuilder.Entity<CandidateSkill>().ToTable("brecruiter_candidateSkills");
            modelBuilder.Entity<CandidateSkill>().HasKey(p => new { p.CandidateId, p.SkillId });

            modelBuilder.Entity<Skill>().ToTable("brecruiter_skills");

            modelBuilder.Entity<CandidateList>().HasKey(pk => new { pk.CreatedDate, pk.ListId });

        }
    }
}
