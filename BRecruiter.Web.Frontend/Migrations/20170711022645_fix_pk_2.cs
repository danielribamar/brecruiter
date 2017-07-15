using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BRecruiter.Web.Frontend.Migrations
{
    public partial class fix_pk_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_brecruiter_candidateSkills_CandidateId_SkillId",
                table: "brecruiter_candidateSkills");

            migrationBuilder.CreateIndex(
                name: "IX_brecruiter_candidateSkills_CandidateId",
                table: "brecruiter_candidateSkills",
                column: "CandidateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_brecruiter_candidateSkills_CandidateId",
                table: "brecruiter_candidateSkills");

            migrationBuilder.CreateIndex(
                name: "IX_brecruiter_candidateSkills_CandidateId_SkillId",
                table: "brecruiter_candidateSkills",
                columns: new[] { "CandidateId", "SkillId" },
                unique: true);
        }
    }
}
