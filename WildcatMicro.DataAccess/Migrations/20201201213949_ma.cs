using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicro.DataAccess.Migrations
{
    public partial class ma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MentorAssignment_AspNetUsers_ApplicationUserId",
                table: "MentorAssignment");

            migrationBuilder.DropIndex(
                name: "IX_MentorAssignment_ApplicationUserId",
                table: "MentorAssignment");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "MentorAssignment",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "MentorAssignment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
