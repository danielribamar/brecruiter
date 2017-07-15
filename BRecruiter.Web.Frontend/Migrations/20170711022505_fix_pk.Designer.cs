using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BRecruiter.Web.Frontend.Data;

namespace BRecruiter.Web.Frontend.Migrations
{
    [DbContext(typeof(BRecruiterContext))]
    [Migration("20170711022505_fix_pk")]
    partial class fix_pk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BRecruiter.Web.Frontend.Models.Database.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Curriculum_FileUrl");

                    b.Property<string>("EmailAddress");

                    b.Property<int>("Experience");

                    b.Property<string>("Name");

                    b.Property<string>("Observations");

                    b.Property<int>("SalaryExpectations");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("brecruiter_candidates");
                });

            modelBuilder.Entity("BRecruiter.Web.Frontend.Models.Database.CandidateList", b =>
                {
                    b.Property<int>("CandidateId");

                    b.Property<int>("ListId");

                    b.HasKey("CandidateId", "ListId");

                    b.HasIndex("ListId");

                    b.ToTable("brecruiter_candidateLists");
                });

            modelBuilder.Entity("BRecruiter.Web.Frontend.Models.Database.CandidateSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CandidateId");

                    b.Property<int>("SkillId");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.HasIndex("CandidateId", "SkillId")
                        .IsUnique();

                    b.ToTable("brecruiter_candidateSkills");
                });

            modelBuilder.Entity("BRecruiter.Web.Frontend.Models.Database.CandidateUpdate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CandidateId");

                    b.Property<DateTime>("Createdate");

                    b.Property<string>("Observations");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("brecruiter_candidateUpdates");
                });

            modelBuilder.Entity("BRecruiter.Web.Frontend.Models.Database.List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("brecruiter_lists");
                });

            modelBuilder.Entity("BRecruiter.Web.Frontend.Models.Database.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("brecruiter_skills");
                });

            modelBuilder.Entity("BRecruiter.Web.Frontend.Models.Database.CandidateList", b =>
                {
                    b.HasOne("BRecruiter.Web.Frontend.Models.Database.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BRecruiter.Web.Frontend.Models.Database.List", "List")
                        .WithMany()
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BRecruiter.Web.Frontend.Models.Database.CandidateSkill", b =>
                {
                    b.HasOne("BRecruiter.Web.Frontend.Models.Database.Candidate", "Candidate")
                        .WithMany("RelationSkills")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BRecruiter.Web.Frontend.Models.Database.Skill", "Skill")
                        .WithMany("CandidateSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BRecruiter.Web.Frontend.Models.Database.CandidateUpdate", b =>
                {
                    b.HasOne("BRecruiter.Web.Frontend.Models.Database.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
