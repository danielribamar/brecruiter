using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BRecruiter.Web.Frontend.Migrations
{
    public partial class NavigationProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_brecruiter_candidateUpdates_CandidateId",
                table: "brecruiter_candidateUpdates",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_brecruiter_candidateSkills_SkillId",
                table: "brecruiter_candidateSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_brecruiter_candidateLists_ListId",
                table: "brecruiter_candidateLists",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_brecruiter_candidateLists_brecruiter_candidates_CandidateId",
                table: "brecruiter_candidateLists",
                column: "CandidateId",
                principalTable: "brecruiter_candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_brecruiter_candidateLists_brecruiter_lists_ListId",
                table: "brecruiter_candidateLists",
                column: "ListId",
                principalTable: "brecruiter_lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_brecruiter_candidateSkills_brecruiter_candidates_CandidateId",
                table: "brecruiter_candidateSkills",
                column: "CandidateId",
                principalTable: "brecruiter_candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_brecruiter_candidateSkills_brecruiter_skills_SkillId",
                table: "brecruiter_candidateSkills",
                column: "SkillId",
                principalTable: "brecruiter_skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_brecruiter_candidateUpdates_brecruiter_candidates_CandidateId",
                table: "brecruiter_candidateUpdates",
                column: "CandidateId",
                principalTable: "brecruiter_candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brecruiter_candidateLists_brecruiter_candidates_CandidateId",
                table: "brecruiter_candidateLists");

            migrationBuilder.DropForeignKey(
                name: "FK_brecruiter_candidateLists_brecruiter_lists_ListId",
                table: "brecruiter_candidateLists");

            migrationBuilder.DropForeignKey(
                name: "FK_brecruiter_candidateSkills_brecruiter_candidates_CandidateId",
                table: "brecruiter_candidateSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_brecruiter_candidateSkills_brecruiter_skills_SkillId",
                table: "brecruiter_candidateSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_brecruiter_candidateUpdates_brecruiter_candidates_CandidateId",
                table: "brecruiter_candidateUpdates");

            migrationBuilder.DropIndex(
                name: "IX_brecruiter_candidateUpdates_CandidateId",
                table: "brecruiter_candidateUpdates");

            migrationBuilder.DropIndex(
                name: "IX_brecruiter_candidateSkills_SkillId",
                table: "brecruiter_candidateSkills");

            migrationBuilder.DropIndex(
                name: "IX_brecruiter_candidateLists_ListId",
                table: "brecruiter_candidateLists");
        }
    }
}
