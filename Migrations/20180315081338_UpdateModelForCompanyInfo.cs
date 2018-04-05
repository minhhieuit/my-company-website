using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MVCThehegeo.Migrations
{
    public partial class UpdateModelForCompanyInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "CompanyInfo",
                newName: "AddressVI");

            migrationBuilder.AddColumn<string>(
                name: "AddressEN",
                table: "CompanyInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressEN",
                table: "CompanyInfo");

            migrationBuilder.RenameColumn(
                name: "AddressVI",
                table: "CompanyInfo",
                newName: "Address");
        }
    }
}
