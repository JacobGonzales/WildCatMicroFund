using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicro.DataAccess.Migrations
{
    public partial class derrekcodeandmeetingdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MeetingDate",
                table: "MentorNotes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetingDate",
                table: "MentorNotes");
        }
    }
}
