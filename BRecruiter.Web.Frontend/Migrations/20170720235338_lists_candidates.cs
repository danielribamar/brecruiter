using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BRecruiter.Web.Frontend.Migrations
{
    public partial class lists_candidates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListId",
                table: "brecruiter_candidates",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateLists",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ListId = table.Column<int>(nullable: false),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateLists", x => new { x.CreatedDate, x.ListId });
                    table.ForeignKey(
                        name: "FK_CandidateLists_brecruiter_candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "brecruiter_candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateLists_Lists_ListId",
                        column: x => x.ListId,
                        principalTable: "Lists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_brecruiter_candidates_ListId",
                table: "brecruiter_candidates",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateLists_CandidateId",
                table: "CandidateLists",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateLists_ListId",
                table: "CandidateLists",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_brecruiter_candidates_Lists_ListId",
                table: "brecruiter_candidates",
                column: "ListId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brecruiter_candidates_Lists_ListId",
                table: "brecruiter_candidates");

            migrationBuilder.DropTable(
                name: "CandidateLists");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.DropIndex(
                name: "IX_brecruiter_candidates_ListId",
                table: "brecruiter_candidates");

            migrationBuilder.DropColumn(
                name: "ListId",
                table: "brecruiter_candidates");
        }
    }
}
