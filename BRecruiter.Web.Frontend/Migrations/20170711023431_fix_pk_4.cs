using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BRecruiter.Web.Frontend.Migrations
{
    public partial class fix_pk_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "brecruiter_candidateSkills");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "brecruiter_candidateSkills",
                nullable: false,
                defaultValue: 0);
        }
    }
}
