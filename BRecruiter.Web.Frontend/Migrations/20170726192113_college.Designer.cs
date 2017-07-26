using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BRecruiter.Web.Frontend.Data;

namespace BRecruiter.Web.Frontend.Migrations
{
    [DbContext(typeof(BRecruiterContext))]
    [Migration("20170726192113_college")]
    partial class college
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

                    b.Property<int?>("CollegeId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<byte[]>("Curriculum_File");

                    b.Property<string>("EmailAddress");

                    b.Property<int>("Experience");

                    b.Property<int?>("ListId");

                    b.Property<string>("Name");

                    b.Property<string>("Observations");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("SalaryExpectations");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CollegeId");

                    b.HasIndex("ListId");

                    b.ToTable("brecruiter_candidates");
                });

            modelBuilder.Entity("BRecruiter.Web.Frontend.Models.Database.CandidateCollege", b =>
                {
                    b.Property<int>("CandidateId");

                    b.Property<int>("Collegeid");

                    b.HasKey("CandidateId", "Collegeid");

                    b.HasIndex("Collegeid");

                    b.ToTable("brecruiter_candidateCollege");
                });

            modelBuilder.Entity("BRecruiter.Web.Frontend.Models.Database.CandidateList", b =>
                {
                    b.Property<int>("CandidateId");

                    b.Property<int>("ListId");

                    b.Property<DateTime>("CreatedDate");

                    b.HasKey("CandidateId", "ListId");

                    b.HasIndex("ListId");

                    b.ToTable("CandidateLists");
                });

            modelBuilder.Entity("BRecruiter.Web.Frontend.Models.Database.CandidateSkill", b =>
                {
                    b.Property<int>("CandidateId");

                    b.Property<int>("SkillId");

                    b.Property<DateTime>("CreatedDate");

                    b.HasKey("CandidateId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("brecruiter_candidateSkills");
                });

            modelBuilder.Entity("BRecruiter.Web.Frontend.Models.Database.College", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("brecruiter_colleges");
                });

            modelBuilder.Entity("BRecruiter.Web.Frontend.Models.Database.List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Lists");
                });

            modelBuilder.Entity("BRecruiter.Web.Frontend.Models.Database.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("brecruiter_skills");
                });

            modelBuilder.Entity("BRecruiter.Web.Frontend.Models.Database.Candidate", b =>
                {
                    b.HasOne("BRecruiter.Web.Frontend.Models.Database.College", "College")
                        .WithMany("Candidates")
                        .HasForeignKey("CollegeId");

                    b.HasOne("BRecruiter.Web.Frontend.Models.Database.List")
                        .WithMany("Candidates")
                        .HasForeignKey("ListId");
                });

            modelBuilder.Entity("BRecruiter.Web.Frontend.Models.Database.CandidateCollege", b =>
                {
                    b.HasOne("BRecruiter.Web.Frontend.Models.Database.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BRecruiter.Web.Frontend.Models.Database.College", "College")
                        .WithMany()
                        .HasForeignKey("Collegeid")
                        .OnDelete(DeleteBehavior.Cascade);
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
        }
    }
}
