using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MVCThehegeo.Migrations
{
    public partial class UpdateModelForMultiLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Timeline",
                newName: "TitleVI");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Timeline",
                newName: "TitleEN");

            migrationBuilder.RenameColumn(
                name: "Function",
                table: "TeamInfo",
                newName: "FunctionVI");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "TeamInfo",
                newName: "FunctionEN");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ServiceCompany",
                newName: "TitleVI");

            migrationBuilder.RenameColumn(
                name: "Intro",
                table: "ServiceCompany",
                newName: "TitleEN");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "ServiceCompany",
                newName: "ContentVI");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Recruitment",
                newName: "TitleVI");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Partner",
                newName: "ContentVI");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FeaturedWork",
                newName: "NameVI");

            migrationBuilder.RenameColumn(
                name: "Intro",
                table: "FeaturedWork",
                newName: "NameEN");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "FeaturedWork",
                newName: "IntroVI");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "About",
                newName: "TitleVI");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "About",
                newName: "ContentVI");

            migrationBuilder.AddColumn<string>(
                name: "ContentEN",
                table: "Timeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentVI",
                table: "Timeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullNameEN",
                table: "TeamInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullNameVI",
                table: "TeamInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentEN",
                table: "ServiceCompany",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntroEN",
                table: "ServiceCompany",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntroVI",
                table: "ServiceCompany",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentEN",
                table: "Recruitment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentVI",
                table: "Recruitment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleEN",
                table: "Recruitment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentEN",
                table: "Partner",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentEN",
                table: "FeaturedWork",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentVI",
                table: "FeaturedWork",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntroEN",
                table: "FeaturedWork",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentEN",
                table: "About",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleEN",
                table: "About",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentEN",
                table: "Timeline");

            migrationBuilder.DropColumn(
                name: "ContentVI",
                table: "Timeline");

            migrationBuilder.DropColumn(
                name: "FullNameEN",
                table: "TeamInfo");

            migrationBuilder.DropColumn(
                name: "FullNameVI",
                table: "TeamInfo");

            migrationBuilder.DropColumn(
                name: "ContentEN",
                table: "ServiceCompany");

            migrationBuilder.DropColumn(
                name: "IntroEN",
                table: "ServiceCompany");

            migrationBuilder.DropColumn(
                name: "IntroVI",
                table: "ServiceCompany");

            migrationBuilder.DropColumn(
                name: "ContentEN",
                table: "Recruitment");

            migrationBuilder.DropColumn(
                name: "ContentVI",
                table: "Recruitment");

            migrationBuilder.DropColumn(
                name: "TitleEN",
                table: "Recruitment");

            migrationBuilder.DropColumn(
                name: "ContentEN",
                table: "Partner");

            migrationBuilder.DropColumn(
                name: "ContentEN",
                table: "FeaturedWork");

            migrationBuilder.DropColumn(
                name: "ContentVI",
                table: "FeaturedWork");

            migrationBuilder.DropColumn(
                name: "IntroEN",
                table: "FeaturedWork");

            migrationBuilder.DropColumn(
                name: "ContentEN",
                table: "About");

            migrationBuilder.DropColumn(
                name: "TitleEN",
                table: "About");

            migrationBuilder.RenameColumn(
                name: "TitleVI",
                table: "Timeline",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "TitleEN",
                table: "Timeline",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "FunctionVI",
                table: "TeamInfo",
                newName: "Function");

            migrationBuilder.RenameColumn(
                name: "FunctionEN",
                table: "TeamInfo",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "TitleVI",
                table: "ServiceCompany",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "TitleEN",
                table: "ServiceCompany",
                newName: "Intro");

            migrationBuilder.RenameColumn(
                name: "ContentVI",
                table: "ServiceCompany",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "TitleVI",
                table: "Recruitment",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "ContentVI",
                table: "Partner",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "NameVI",
                table: "FeaturedWork",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameEN",
                table: "FeaturedWork",
                newName: "Intro");

            migrationBuilder.RenameColumn(
                name: "IntroVI",
                table: "FeaturedWork",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "TitleVI",
                table: "About",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ContentVI",
                table: "About",
                newName: "Content");
        }
    }
}
