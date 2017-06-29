using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BRecruiter.Web.Frontend.Migrations
{
    public partial class CANDIDATE_UPD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "brecruiter_candidates");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "brecruiter_candidates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "brecruiter_candidates");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "brecruiter_candidates",
                nullable: false,
                defaultValue: 0);
        }
    }
}
