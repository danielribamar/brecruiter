using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BRecruiter.Web.Frontend.Migrations
{
    public partial class fix_pk_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_brecruiter_candidateSkills",
                table: "brecruiter_candidateSkills");

            migrationBuilder.DropIndex(
                name: "IX_brecruiter_candidateSkills_CandidateId",
                table: "brecruiter_candidateSkills");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "brecruiter_candidateSkills",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_brecruiter_candidateSkills",
                table: "brecruiter_candidateSkills",
                columns: new[] { "CandidateId", "SkillId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_brecruiter_candidateSkills",
                table: "brecruiter_candidateSkills");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "brecruiter_candidateSkills",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_brecruiter_candidateSkills",
                table: "brecruiter_candidateSkills",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_brecruiter_candidateSkills_CandidateId",
                table: "brecruiter_candidateSkills",
                column: "CandidateId");
        }
    }
}
