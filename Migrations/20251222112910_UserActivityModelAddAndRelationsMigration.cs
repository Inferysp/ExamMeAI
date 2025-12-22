using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamMeAI.Migrations
{
    /// <inheritdoc />
    public partial class UserActivityModelAddAndRelationsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AiModel",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AiService",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserActivity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    examinationId = table.Column<int>(type: "int", nullable: false),
                    IsExaminedByAI = table.Column<bool>(type: "bit", nullable: false),
                    ActivityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActivityUserInput = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserActivity_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserActivity_UsersId",
                table: "UserActivity",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserActivity");

            migrationBuilder.DropColumn(
                name: "AiModel",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "AiService",
                table: "Exams");
        }
    }
}
