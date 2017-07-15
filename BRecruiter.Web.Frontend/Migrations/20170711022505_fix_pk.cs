using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BRecruiter.Web.Frontend.Migrations
{
    public partial class fix_pk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brecruiter_skills_brecruiter_candidates_CandidateId",
                table: "brecruiter_skills");

            migrationBuilder.DropIndex(
                name: "IX_brecruiter_skills_CandidateId",
                table: "brecruiter_skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_brecruiter_candidateSkills",
                table: "brecruiter_candidateSkills");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "brecruiter_skills");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "brecruiter_candidateSkills",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_brecruiter_candidateSkills",
                table: "brecruiter_candidateSkills",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_brecruiter_candidateSkills_CandidateId_SkillId",
                table: "brecruiter_candidateSkills",
                columns: new[] { "CandidateId", "SkillId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_brecruiter_candidateSkills",
                table: "brecruiter_candidateSkills");

            migrationBuilder.DropIndex(
                name: "IX_brecruiter_candidateSkills_CandidateId_SkillId",
                table: "brecruiter_candidateSkills");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "brecruiter_candidateSkills");

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "brecruiter_skills",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_brecruiter_candidateSkills",
                table: "brecruiter_candidateSkills",
                columns: new[] { "CandidateId", "SkillId" });

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
    }
}
