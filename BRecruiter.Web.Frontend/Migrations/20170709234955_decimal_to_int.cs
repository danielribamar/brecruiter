using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BRecruiter.Web.Frontend.Migrations
{
    public partial class decimal_to_int : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SalaryExpectations",
                table: "brecruiter_candidates",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "Experience",
                table: "brecruiter_candidates",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SalaryExpectations",
                table: "brecruiter_candidates",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Experience",
                table: "brecruiter_candidates",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
