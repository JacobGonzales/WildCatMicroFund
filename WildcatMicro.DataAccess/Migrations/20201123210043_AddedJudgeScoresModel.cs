using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicro.DataAccess.Migrations
{
    public partial class AddedJudgeScoresModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JudgeScores",
                columns: table => new
                {
                    JudgeScoresId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<float>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    JudgeQuestionsId = table.Column<int>(nullable: false),
                    ScoreCardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JudgeScores", x => x.JudgeScoresId);
                    table.ForeignKey(
                        name: "FK_JudgeScores_JudgeQuestions_JudgeQuestionsId",
                        column: x => x.JudgeQuestionsId,
                        principalTable: "JudgeQuestions",
                        principalColumn: "JudgeQuestionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JudgeScores_ScoreCard_ScoreCardId",
                        column: x => x.ScoreCardId,
                        principalTable: "ScoreCard",
                        principalColumn: "ScoreCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JudgeScores_JudgeQuestionsId",
                table: "JudgeScores",
                column: "JudgeQuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_JudgeScores_ScoreCardId",
                table: "JudgeScores",
                column: "ScoreCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JudgeScores");
        }
    }
}
