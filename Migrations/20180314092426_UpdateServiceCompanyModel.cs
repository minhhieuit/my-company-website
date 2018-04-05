using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MVCThehegeo.Migrations
{
    public partial class UpdateServiceCompanyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "ServiceCompany",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Intro",
                table: "ServiceCompany",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "ServiceCompany");

            migrationBuilder.DropColumn(
                name: "Intro",
                table: "ServiceCompany");
        }
    }
}
