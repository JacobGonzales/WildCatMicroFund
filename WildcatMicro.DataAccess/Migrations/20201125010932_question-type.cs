using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicro.DataAccess.Migrations
{
    public partial class questiontype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Questions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Questions");
        }
    }
}
