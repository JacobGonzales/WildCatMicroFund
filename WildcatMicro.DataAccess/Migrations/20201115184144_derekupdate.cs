using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicro.DataAccess.Migrations
{
    public partial class derekupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JudgeScores_ScoreCard_ScoreCardId",
                table: "JudgeScores");

            migrationBuilder.DropIndex(
                name: "IX_JudgeScores_ScoreCardId",
                table: "JudgeScores");

            migrationBuilder.DropColumn(
                name: "JudgeScore",
                table: "JudgeScores");

            migrationBuilder.DropColumn(
                name: "ScoreCardId",
                table: "JudgeScores");

            migrationBuilder.AddColumn<string>(
                name: "JudgeScores",
                table: "ScoreCard",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JudgeScores",
                table: "ScoreCard");

            migrationBuilder.AddColumn<int>(
                name: "JudgeScore",
                table: "JudgeScores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScoreCardId",
                table: "JudgeScores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JudgeScores_ScoreCardId",
                table: "JudgeScores",
                column: "ScoreCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_JudgeScores_ScoreCard_ScoreCardId",
                table: "JudgeScores",
                column: "ScoreCardId",
                principalTable: "ScoreCard",
                principalColumn: "ScoreCardId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
