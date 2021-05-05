using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicro.DataAccess.Migrations
{
    public partial class applicantuserinapp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Applicant",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applicant_ApplicationUserId",
                table: "Applicant",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicant_AspNetUsers_ApplicationUserId",
                table: "Applicant",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicant_AspNetUsers_ApplicationUserId",
                table: "Applicant");

            migrationBuilder.DropIndex(
                name: "IX_Applicant_ApplicationUserId",
                table: "Applicant");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Applicant");
        }
    }
}
