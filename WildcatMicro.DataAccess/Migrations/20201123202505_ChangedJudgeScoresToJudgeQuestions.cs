using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicro.DataAccess.Migrations
{
    public partial class ChangedJudgeScoresToJudgeQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JudgeScores");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "ScoreCard");

            migrationBuilder.DropColumn(
                name: "JudgeScores",
                table: "ScoreCard");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "ScoreCard");

            migrationBuilder.AddColumn<double>(
                name: "TotalScore",
                table: "ScoreCard",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "JudgeQuestions",
                columns: table => new
                {
                    JudgeQuestionsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<float>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JudgeQuestions", x => x.JudgeQuestionsId);
                    table.ForeignKey(
                        name: "FK_JudgeQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JudgeQuestions_QuestionId",
                table: "JudgeQuestions",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JudgeQuestions");

            migrationBuilder.DropColumn(
                name: "TotalScore",
                table: "ScoreCard");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "ScoreCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JudgeScores",
                table: "ScoreCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "ScoreCard",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "JudgeScores",
                columns: table => new
                {
                    JudgeScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JudgeScores", x => x.JudgeScoreId);
                    table.ForeignKey(
                        name: "FK_JudgeScores_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JudgeScores_QuestionId",
                table: "JudgeScores",
                column: "QuestionId");
        }
    }
}
