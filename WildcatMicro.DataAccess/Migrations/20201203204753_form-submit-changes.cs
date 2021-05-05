using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicro.DataAccess.Migrations
{
    public partial class formsubmitchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ASK",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "BusinessAddress",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "BusinessCity",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "BusinessCounty",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "BusinessCreationDate",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "BusinessPhone",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "BusinessStatus",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "BusinessZip",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "ExternalFunding",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "FundsRequested",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "IntellectualProp",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "LinkToAQ",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "Prototype",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "Revenue",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "CellPhone",
                table: "Applicant");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Applicant");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Applicant");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Applicant");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Applicant");

            migrationBuilder.DropColumn(
                name: "HomeAddress",
                table: "Applicant");

            migrationBuilder.DropColumn(
                name: "HomeCity",
                table: "Applicant");

            migrationBuilder.DropColumn(
                name: "HomeCounty",
                table: "Applicant");

            migrationBuilder.DropColumn(
                name: "HomeZip",
                table: "Applicant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ASK",
                table: "Business",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessAddress",
                table: "Business",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessCity",
                table: "Business",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessCounty",
                table: "Business",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessCreationDate",
                table: "Business",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessPhone",
                table: "Business",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessStatus",
                table: "Business",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusinessZip",
                table: "Business",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ExternalFunding",
                table: "Business",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FundsRequested",
                table: "Business",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IntellectualProp",
                table: "Business",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkToAQ",
                table: "Business",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prototype",
                table: "Business",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                table: "Business",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Revenue",
                table: "Business",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Business",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CellPhone",
                table: "Applicant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Applicant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Applicant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Applicant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Applicant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress",
                table: "Applicant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeCity",
                table: "Applicant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeCounty",
                table: "Applicant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeZip",
                table: "Applicant",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
