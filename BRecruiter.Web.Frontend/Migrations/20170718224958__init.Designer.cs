﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BRecruiter.Web.Frontend.Data;

namespace BRecruiter.Web.Frontend.Migrations
{
    [DbContext(typeof(BRecruiterContext))]
    [Migration("20170718224958__init")]
    partial class _init
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

                    b.Property<DateTime>("CreatedDate");

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

            modelBuilder.Entity("BRecruiter.Web.Frontend.Models.Database.CandidateSkill", b =>
                {
                    b.Property<int>("CandidateId");

                    b.Property<int>("SkillId");

                    b.Property<DateTime>("CreatedDate");

                    b.HasKey("CandidateId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("brecruiter_candidateSkills");
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
