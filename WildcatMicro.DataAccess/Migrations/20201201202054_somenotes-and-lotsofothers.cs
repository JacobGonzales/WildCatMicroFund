using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicro.DataAccess.Migrations
{
    public partial class somenotesandlotsofothers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MentorAssignment_AspNetUsers_ApplicationUserFullName",
                table: "MentorAssignment");

            migrationBuilder.DropIndex(
                name: "IX_MentorAssignment_ApplicationUserFullName",
                table: "MentorAssignment");

            migrationBuilder.DropColumn(
                name: "ApplicationUserFullName",
                table: "MentorAssignment");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "MentorAssignment",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                table: "MentorAssignment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_MentorAssignment_ApplicationUserId",
                table: "MentorAssignment",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MentorAssignment_AspNetUsers_ApplicationUserId",
                table: "MentorAssignment",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MentorAssignment_AspNetUsers_ApplicationUserId",
                table: "MentorAssignment");

            migrationBuilder.DropIndex(
                name: "IX_MentorAssignment_ApplicationUserId",
                table: "MentorAssignment");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "MentorAssignment");

            migrationBuilder.DropColumn(
                name: "enabled",
                table: "MentorAssignment");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserFullName",
                table: "MentorAssignment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MentorAssignment_ApplicationUserFullName",
                table: "MentorAssignment",
                column: "ApplicationUserFullName");

            migrationBuilder.AddForeignKey(
                name: "FK_MentorAssignment_AspNetUsers_ApplicationUserFullName",
                table: "MentorAssignment",
                column: "ApplicationUserFullName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
