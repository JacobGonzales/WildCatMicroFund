using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicro.DataAccess.Migrations
{
    public partial class DeletedScoreCardModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JudgeScores_ScoreCard_ScoreCardId",
                table: "JudgeScores");

            migrationBuilder.DropTable(
                name: "ScoreCard");

            migrationBuilder.DropIndex(
                name: "IX_JudgeScores_ScoreCardId",
                table: "JudgeScores");

            migrationBuilder.DropColumn(
                name: "ScoreCardId",
                table: "JudgeScores");

            migrationBuilder.AddColumn<int>(
                name: "PitchId",
                table: "JudgeScores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JudgeScores_PitchId",
                table: "JudgeScores",
                column: "PitchId");

            migrationBuilder.AddForeignKey(
                name: "FK_JudgeScores_Pitch_PitchId",
                table: "JudgeScores",
                column: "PitchId",
                principalTable: "Pitch",
                principalColumn: "PitchId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JudgeScores_Pitch_PitchId",
                table: "JudgeScores");

            migrationBuilder.DropIndex(
                name: "IX_JudgeScores_PitchId",
                table: "JudgeScores");

            migrationBuilder.DropColumn(
                name: "PitchId",
                table: "JudgeScores");

            migrationBuilder.AddColumn<int>(
                name: "ScoreCardId",
                table: "JudgeScores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ScoreCard",
                columns: table => new
                {
                    ScoreCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PitchId = table.Column<int>(type: "int", nullable: false),
                    TotalScore = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreCard", x => x.ScoreCardId);
                    table.ForeignKey(
                        name: "FK_ScoreCard_Pitch_PitchId",
                        column: x => x.PitchId,
                        principalTable: "Pitch",
                        principalColumn: "PitchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JudgeScores_ScoreCardId",
                table: "JudgeScores",
                column: "ScoreCardId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCard_PitchId",
                table: "ScoreCard",
                column: "PitchId");

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
