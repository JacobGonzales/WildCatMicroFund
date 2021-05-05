using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicro.DataAccess.Migrations
{
    public partial class statuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationStatus",
                table: "Application");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Application",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_StatusId",
                table: "Application",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Statuses_StatusId",
                table: "Application",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Statuses_StatusId",
                table: "Application");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Application_StatusId",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Application");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationStatus",
                table: "Application",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
