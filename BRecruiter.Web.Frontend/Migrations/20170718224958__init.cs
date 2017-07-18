using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BRecruiter.Web.Frontend.Migrations
{
    public partial class _init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brecruiter_candidates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Curriculum_FileUrl = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Experience = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Observations = table.Column<string>(nullable: true),
                    SalaryExpectations = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brecruiter_candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "brecruiter_skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brecruiter_skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "brecruiter_candidateSkills",
                columns: table => new
                {
                    CandidateId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brecruiter_candidateSkills", x => new { x.CandidateId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_brecruiter_candidateSkills_brecruiter_candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "brecruiter_candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_brecruiter_candidateSkills_brecruiter_skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "brecruiter_skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_brecruiter_candidateSkills_SkillId",
                table: "brecruiter_candidateSkills",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "brecruiter_candidateSkills");

            migrationBuilder.DropTable(
                name: "brecruiter_candidates");

            migrationBuilder.DropTable(
                name: "brecruiter_skills");
        }
    }
}
