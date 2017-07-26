using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BRecruiter.Web.Frontend.Migrations
{
    public partial class college : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateLists",
                table: "CandidateLists");

            migrationBuilder.DropIndex(
                name: "IX_CandidateLists_CandidateId",
                table: "CandidateLists");

            migrationBuilder.AddColumn<int>(
                name: "CollegeId",
                table: "brecruiter_candidates",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateLists",
                table: "CandidateLists",
                columns: new[] { "CandidateId", "ListId" });

            migrationBuilder.CreateTable(
                name: "brecruiter_colleges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brecruiter_colleges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "brecruiter_candidateCollege",
                columns: table => new
                {
                    CandidateId = table.Column<int>(nullable: false),
                    Collegeid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brecruiter_candidateCollege", x => new { x.CandidateId, x.Collegeid });
                    table.ForeignKey(
                        name: "FK_brecruiter_candidateCollege_brecruiter_candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "brecruiter_candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_brecruiter_candidateCollege_brecruiter_colleges_Collegeid",
                        column: x => x.Collegeid,
                        principalTable: "brecruiter_colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_brecruiter_candidates_CollegeId",
                table: "brecruiter_candidates",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_brecruiter_candidateCollege_Collegeid",
                table: "brecruiter_candidateCollege",
                column: "Collegeid");

            migrationBuilder.AddForeignKey(
                name: "FK_brecruiter_candidates_brecruiter_colleges_CollegeId",
                table: "brecruiter_candidates",
                column: "CollegeId",
                principalTable: "brecruiter_colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brecruiter_candidates_brecruiter_colleges_CollegeId",
                table: "brecruiter_candidates");

            migrationBuilder.DropTable(
                name: "brecruiter_candidateCollege");

            migrationBuilder.DropTable(
                name: "brecruiter_colleges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateLists",
                table: "CandidateLists");

            migrationBuilder.DropIndex(
                name: "IX_brecruiter_candidates_CollegeId",
                table: "brecruiter_candidates");

            migrationBuilder.DropColumn(
                name: "CollegeId",
                table: "brecruiter_candidates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateLists",
                table: "CandidateLists",
                columns: new[] { "CreatedDate", "ListId" });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateLists_CandidateId",
                table: "CandidateLists",
                column: "CandidateId");
        }
    }
}
