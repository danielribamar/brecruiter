using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BRecruiter.Web.Frontend.Migrations
{
    public partial class Lists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "brecruiter_skills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Curriculum_FileUrl",
                table: "brecruiter_candidates",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Experience",
                table: "brecruiter_candidates",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "brecruiter_candidates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "brecruiter_candidateLists",
                columns: table => new
                {
                    CandidateId = table.Column<int>(nullable: false),
                    ListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brecruiter_candidateLists", x => new { x.CandidateId, x.ListId });
                });

            migrationBuilder.CreateTable(
                name: "brecruiter_candidateSkills",
                columns: table => new
                {
                    CandidateId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brecruiter_candidateSkills", x => new { x.CandidateId, x.SkillId });
                });

            migrationBuilder.CreateTable(
                name: "brecruiter_lists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brecruiter_lists", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_brecruiter_skills_CandidateId",
                table: "brecruiter_skills",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_brecruiter_skills_brecruiter_candidates_CandidateId",
                table: "brecruiter_skills",
                column: "CandidateId",
                principalTable: "brecruiter_candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brecruiter_skills_brecruiter_candidates_CandidateId",
                table: "brecruiter_skills");

            migrationBuilder.DropTable(
                name: "brecruiter_candidateLists");

            migrationBuilder.DropTable(
                name: "brecruiter_candidateSkills");

            migrationBuilder.DropTable(
                name: "brecruiter_lists");

            migrationBuilder.DropIndex(
                name: "IX_brecruiter_skills_CandidateId",
                table: "brecruiter_skills");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "brecruiter_skills");

            migrationBuilder.DropColumn(
                name: "Curriculum_FileUrl",
                table: "brecruiter_candidates");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "brecruiter_candidates");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "brecruiter_candidates");
        }
    }
}
