using BRecruiter.Web.Frontend.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace BRecruiter.Web.Frontend.Data
{
    public class BRecruiterContext : DbContext
    {
        public BRecruiterContext(DbContextOptions<BRecruiterContext> options)
        : base(options)
        { }

        public DbSet<List> Lists { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateUpdate> CandidateUpdates { get; set; }
        public DbSet<CandidateList> CandidateLists { get; set; }
        public DbSet<CandidateSkill> CandidateSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Skill>().ToTable("brecruiter_skills");
            modelBuilder.Entity<Skill>().HasKey(pk => pk.Id);
            modelBuilder.Entity<Skill>().HasMany(hm => hm.CandidateSkills).WithOne(p => p.Skill);


            modelBuilder.Entity<List>().ToTable("brecruiter_lists");
            modelBuilder.Entity<List>().HasKey(pk => new { pk.Id });

            modelBuilder.Entity<Candidate>().ToTable("brecruiter_candidates");
            modelBuilder.Entity<Candidate>().HasKey(pk => pk.Id);
            modelBuilder.Entity<Candidate>().HasMany(hm => hm.RelationSkills).WithOne(p => p.Candidate);

            modelBuilder.Entity<CandidateUpdate>().ToTable("brecruiter_candidateUpdates");
            modelBuilder.Entity<CandidateUpdate>().HasKey(pk => pk.Id);

            modelBuilder.Entity<CandidateSkill>().ToTable("brecruiter_candidateSkills");
            modelBuilder.Entity<CandidateSkill>().HasKey(pk => new { pk.CandidateId, pk.SkillId });
            modelBuilder.Entity<CandidateSkill>().HasOne(hm => hm.Skill).WithMany(p => p.CandidateSkills);

            modelBuilder.Entity<CandidateList>().ToTable("brecruiter_candidateLists");
            modelBuilder.Entity<CandidateList>().HasKey(pk => new { pk.CandidateId, pk.ListId });
        }
    }
}
